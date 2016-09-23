namespace LivePhotoShow.Messages
{
    class ShowPhoto
    {
        public string Path { get; }

        public ShowPhoto(string path)
        {
            this.Path = path;
        }
    }
}