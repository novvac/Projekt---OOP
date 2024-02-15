using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w67166_OP
{
    abstract class DatabaseManager
    {
        protected string filename;

        public DatabaseManager(string name)
        {
            filename = name;
        }

        public string FormatData(string[] data, bool active = true)
        {
            string isActive = active ? "active" : "archived";

            return String.Join(";", [this.GetLastId() + 1, ..data, isActive]);
        }

        public int GetLastId()
        {
            string line = File.ReadLines(filename).LastOrDefault();

            if(line == null)
            {
                return 0;
            }

            string[] lineValues = line.Split(';');

            return Convert.ToInt32(lineValues[0]);
        }

        public void AppendToFile(string[] lines)
        {
            File.AppendAllLines(filename, lines);
        }

        public string[] Where(int index, string value)
        {
            string[] items = [];

            foreach(string item in Read())
            {
                if (item.Split(";")[index] == value)
                    items = [..items, item];
            }

            return items;
        }

        public static string[] Filter(string[] items, int index, string value)
        {
            string[] filtered = [];

            foreach (string item in items)
            {
                string[] itemValues = item.Split(";");

                if (itemValues[index] == value)
                    filtered = [.. filtered, item];
            }

            return filtered;
        }

        public string[] Deserialize(string item)
        {
            return item.Split(";");
        }

        public void DeleteHelper(string id)
        {
            string[] lines = Read();
            List<string> newLines = new List<string>();

            foreach (string line in lines)
            {
                string[] lineValues = line.Split(';');

                if (lineValues[0] != id)
                    newLines.Add(line);
            }

            File.WriteAllLines(filename, newLines.ToArray());
        }

        // CRUD actions
        public abstract void Create();
        public abstract string[] Read();
        public abstract void Delete();
    }
}
