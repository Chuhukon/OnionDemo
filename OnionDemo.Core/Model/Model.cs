using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Core.Model
{
    public enum Genre
    {
        Pop,
        Alternative,
        Classic,
        Rock
    }

    public class Album
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Artist { get; set; }

        public Genre Genre { get; set; }
    }
}
