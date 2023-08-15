using System;
using System.IO;
using System.Diagnostics;

namespace AutoImagePlayer
{
    class Program
    {

        static void Main(string[] args)
        {
            // Ruta de la carpeta temporal donde se copiarán las imágenes
            string tempFolderPath = Path.Combine(Path.GetTempPath(), "AutoImagePlayer");

            // Verificar si la carpeta temporal ya existe y crearla si no
            if (!Directory.Exists(tempFolderPath))
                Directory.CreateDirectory(tempFolderPath);

            // Escuchar eventos de inserción de dispositivos USB
            var watcher = new DriveWatcher();
            watcher.DriveInserted += OnDriveInserted;
            watcher.Start();

            Console.WriteLine("Esperando la inserción de una memoria USB...");

            // Mantener la aplicación en ejecución
            Console.ReadLine();

            // Detener el escucha de eventos
            watcher.Stop();
        }

        static void OnDriveInserted(object sender, DriveInfo driveInfo)
        {
            string tempFolderPath = Path.Combine(Path.GetTempPath(), "AutoImagePlayer");
            if (IsImageDrive(driveInfo))
            {
                Console.WriteLine($"Memoria USB detectada en la unidad: {driveInfo.RootDirectory}");

                // Obtener la lista de archivos de imagen en la memoria USB
                var imageFiles = Directory.GetFiles(driveInfo.RootDirectory.FullName, "*.jpg;*.jpeg;*.png;*.gif");

                if (imageFiles.Length > 0)
                {
                    // Copiar las imágenes a la carpeta temporal
                    foreach (var imageFile in imageFiles)
                    {
                        string tempFilePath = Path.Combine(tempFolderPath, Path.GetFileName(imageFile));
                        File.Copy(imageFile, tempFilePath, true);
                    }

                    // Reproducir las imágenes utilizando la aplicación predeterminada
                    Process.Start(tempFolderPath);
                }
                else
                {
                    Console.WriteLine("La memoria USB no contiene imágenes.");
                }
            }
        }

        static bool IsImageDrive(DriveInfo driveInfo)
        {
            // Verificar si la unidad es extraíble y tiene el tipo de archivo compatible
            return driveInfo.DriveType == DriveType.Removable &&
                   (driveInfo.TotalSize > 0 || driveInfo.AvailableFreeSpace > 0) &&
                   (driveInfo.VolumeLabel != null || driveInfo.VolumeLabel != string.Empty);
        }
    }

    class DriveWatcher
    {
        public event EventHandler<DriveInfo> DriveInserted;

        private bool isWatching = false;

        public void Start()
        {
            if (!isWatching)
            {
                isWatching = true;
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    if (drive.DriveType == DriveType.Removable)
                    {
                        Console.WriteLine($"Escuchando la unidad: {drive.RootDirectory}");
                        Console.WriteLine();
                    }
                }

                // Verificar cambios de dispositivos en un intervalo de tiempo
                while (isWatching)
                {
                    DriveInfo[] currentDrives = DriveInfo.GetDrives();

                    foreach (DriveInfo drive in currentDrives)
                    {
                        if (drive.DriveType == DriveType.Removable && !drive.IsReady)
                        {
                            Console.WriteLine($"Memoria USB extraída de la unidad: {drive.RootDirectory}");
                            Console.WriteLine();
                        }
                        else if (drive.DriveType == DriveType.Removable && drive.IsReady)
                        {
                            bool isNewDrive = true;

                            foreach (DriveInfo prevDrive in drives)
                            {
                                if (prevDrive.RootDirectory.FullName == drive.RootDirectory.FullName)
                                {
                                    isNewDrive = false;
                                    break;
                                }
                            }

                            if (isNewDrive)
                            {
                                DriveInserted?.Invoke(this, drive);
                            }
                        }
                    }

                    drives = currentDrives;

                    // Esperar 1 segundo antes de verificar cambios nuevamente
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        public void Stop()
        {
            isWatching = false;
        }
    }
}





