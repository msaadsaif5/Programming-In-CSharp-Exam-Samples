using System;

namespace ReferenceTypes
{
    class Report : IPrintable<Report>, IDownloadable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset GeneratedOn { get; set; }

        public void Print(Report obj)
        {
            Console.WriteLine($"Report with title '{Title}' was generated on {GeneratedOn}");
        }

        void IDownloadable.Download(string path, string format)
        {
            //download logic here
        }
    }
}
