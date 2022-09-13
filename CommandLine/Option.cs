using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecSploit.CommandLine
{
    internal class Option<T>
    {
        public String name;
        public String description;
        public String value = "";
        public T defaultValue;
        public Boolean required = true;

        public Option(String name, String description)
        {
            this.name = name;
            this.description = description;
        }
        public Option(String name, String description, T defaultValue) {
            this.name = name;
            this.description = description; 
            this.defaultValue = defaultValue;
            if (defaultValue.ToString() == "")
            {
                this.required = false;
            }
            else { 
                this.required = true;  
            }


        }

        public bool HasDefaultValue() {
            return this.defaultValue != null;
        }
    }
}
