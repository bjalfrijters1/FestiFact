using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Mobile.Models
{
    internal class Note
    {
        public string FileName { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Note()
        {
            FileName = $"{Path.GetRandomFileName()}.notes.txt";
            Date = DateTime.Now;
            Text = "";
        }

        public void Save() =>
            File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, FileName), Text);

        public void Delete() =>
            File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, FileName));

        public static Note Load(string filename)
        {
            filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

            if(!File.Exists(filename))
            {
                throw new FileNotFoundException(filename);
            }

            return
                new()
                {
                    FileName = Path.GetFileName(filename),
                    Text = File.ReadAllText(filename),
                    Date = File.GetLastWriteTime(filename)
                };
        }

        public static IEnumerable<Note> LoadAll()
        {
            string appDataPath = FileSystem.AppDataDirectory;

            //use linq extensions to load the *.notes.txt files
            return Directory
                //Select file names from directory
                .EnumerateDirectories(appDataPath, "*.notes.txt")
                //Each file name is used to load a note
                .Select(filename => Note.Load(Path.GetFileName(filename)))
                //With the final collection of notes, order by date desc.
                .OrderByDescending(note => note.Date);
        }
    }
}
