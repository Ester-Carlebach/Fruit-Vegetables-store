using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    //אוביקט זה נשלח חזרה לצד לקוח מפונקצית חישוב הקניה
    //נתונים בו המאפיינים של:
    //סכום, סכום סופי לאחר הנחות, כמות מוצרים, סכום הנחות, האם יש ללקוח 
    //יומולדת בחודש זה
    public class Receipt
    {
        public double Sum { get; set; }
        public double TotalSum { get; set; }
        public int Count { get; set; }
        public double SumDiscount { get; set; }
        public bool Birthday { get; set; }
    }
}
