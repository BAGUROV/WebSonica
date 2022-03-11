namespace SonicaWebAdmin.Services
{
    public class FileModel
    {
        public FileModel(string fileName, byte[] fileContent)
        {
            Name = fileName;
            Content = fileContent;
        }

        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}