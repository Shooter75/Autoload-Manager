using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutorunMonitor.TMC
{
    public class RegisterModel
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            RegisterModel compareObj = obj as RegisterModel;
            bool contition = false;

            if (compareObj.Key == this.Key && compareObj.Value == this.Value)
                contition = true;
            
            return contition;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
