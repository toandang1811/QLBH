using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UIConfigs
{
    public class FieldObject
    {
        public string ObjectId { get; set; }
        public string FieldId { get; set; }
        public string FieldName { get; set; }
        public string LanguageId { get; set; }
        public string Description { get; set; }
        public bool IsColumn { get; set; }
        public bool IsVisible { get; set; }
        public int Orders { get; set; }
        public bool IsPrimaryKey { get; set; }
        public string DataType { get; set; }
        public string DataTypeName { get; set; }
    }
}
