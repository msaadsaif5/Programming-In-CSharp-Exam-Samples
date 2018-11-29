using System;

namespace ReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var report = new Report { Id = 1, Title = "MyReport", GeneratedOn = DateTimeOffset.Now };
            report.Print(report);

            //Download method is not accessible as Reprot class implements the IDownloadable interface explicitly
            //report.Download(@"C:\", "pdf");

            //can access after casting to IDownloadable interface
            ((IDownloadable)report).Download(@"C:\", "pdf");

            Console.ReadLine();
        }
    }
}
