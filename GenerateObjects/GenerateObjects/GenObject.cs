using System;

namespace GenerateObjects
{

    public class NoneClassException : Exception { }

    public class GenObject: IGenObject
    {

        private enum TypeObject
        {
            First = 1,
            Second = 2,
            Tird = 3,
        }

        private readonly int _type;

        public double Dvalue { get; set; }

        public GenObject(int type, double dvalue)
        {
            this.Dvalue = dvalue;
            this._type = type;
            if (_type != (int)TypeObject.First && _type != (int)TypeObject.Second && _type != (int)TypeObject.Tird)
            {
                throw new NoneClassException();
            }
        }

        public GenObject()
        {
            this.Dvalue = 0;
            this._type = (int)TypeObject.First;
        }

        public int GetTypeObject()
        {
            return _type;
        }

        public double GetDValue()
        {
            return Dvalue;
        }



    }


}