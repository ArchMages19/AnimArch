﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationControl
{

    public class CDClass
    {
        public string Name { get; set; }
        public List<CDAttribute> Attributes { get; set; }
        public List<CDMethod> Methods { get; set; }
        public List<CDClassInstance> Instances { get; set; }
        private long ClassIDPrefix;
        private long InstanceIDSeed;

        public const String Undefined = "UNDEFINED";

        public CDClass(long ClassIDPrefix, String Name, List<String> AttributeNames, List<String> MethodNames)
        {
            this.ClassIDPrefix = ClassIDPrefix;
            this.InstanceIDSeed = 0;
            this.Name = Name;

            this.Attributes = new List<CDAttribute>();
            foreach(String AttributeName in AttributeNames)
            {
                this.Attributes.Add(new CDAttribute(AttributeName, "NoType"));
            }

            this.Methods = new List<CDMethod>();
            foreach(String MethodName in MethodNames)
            {
                this.Methods.Add(new CDMethod(MethodName, "NoType"));
            }

            this.Instances = new List<CDClassInstance>();
        }

        public CDClassInstance CreateClassInstance(String InstanceName)
        {

            long NewInstanceID = ConstructNewInstanceUniqueID();
            this.InstanceIDSeed++;

            CDClassInstance Instance = new CDClassInstance(NewInstanceID, this.Attributes);
            Instance.AddReferencingVariable(InstanceName);
            this.Instances.Add(Instance);

            return Instance;
        }
        public CDClassInstance FindInstanceByName(String InstanceName)
        {
            CDClassInstance SearchedInstance = null;
            foreach (CDClassInstance Instance in this.Instances)
            {
                foreach (String VariableName in Instance.ReferencingVariables)
                {
                    if (VariableName == InstanceName)
                    {
                        SearchedInstance = Instance;
                        break;
                    }
                }
                if (SearchedInstance != null)
                {
                    break;
                }
            }
            return SearchedInstance;
        }
        private long ConstructNewInstanceUniqueID()
        {
            int DigitCount = this.InstanceIDSeed.ToString().Length;
            long NewInstanceID = ClassIDPrefix * PowerOf(10, DigitCount) + InstanceIDSeed;

            return NewInstanceID;
        }

        private int PowerOf(int x, int power)
        {
            int result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= x;
            }

            return result;
        }
    }
}
