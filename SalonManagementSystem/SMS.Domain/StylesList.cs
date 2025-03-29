using SMS.Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain
{
    public class StylesList : CommonClass
    {
        public Guid StylesListId { get; set; }
        public string StyleImg { get; set; }
        public string StyleName { get; set; }
        public string StyleDescription {  get; set; }

    }
}
