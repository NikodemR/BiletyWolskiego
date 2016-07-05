using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace Bilety
{
    class KartaMiejska
    {
        public string NrAlbumu { get; set; }
        public string TypUczelni { get; set; }
        public enum RodzajUczelni
        {
        KKM = 0,    
        WSZiB = 20,
		AGH,
		UJ,
		PK,
		UE,
		UR,
		PWST,
		AM,
		WSE,
		AIK_WSFP,
		UP,
		WSH,
		KA,
		WSEI,
		IFJ_PAN,
		IKiFP_PAN,
        }
        
    }
}
