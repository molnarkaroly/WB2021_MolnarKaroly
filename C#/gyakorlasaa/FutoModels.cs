using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futoverseny
{
    public class FutoItem
    {
        public int rajtszam { get; set; }
        public string nev { get; set; }
        public string birth { get; set; }
        public string orszag { get; set; }
        public string ido { get; set; }

        public FutoItem(int rajtszam, string nev, string birth, string orszag, string ido)
        {
            this.rajtszam = rajtszam;
            this.nev = nev;
            this.birth = birth;
            this.orszag = orszag;
            this.ido = ido;
        }
    }
}
