using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_GLII.Models
{
    

   
        // Placeholder pour représenter le flux vidéo retourné par Film.Visionner()
        public class DataStream
        {
            public string StreamId { get; set; }
            public DateTime CreatedAt { get; set; }

            public DataStream()
            {
                StreamId = Guid.NewGuid().ToString();
                CreatedAt = DateTime.Now;
            }

            // Méthodes utilitaires simulées
            public void Start() { /* simulation */ }
            public void Stop() { /* simulation */ }
        }

}
