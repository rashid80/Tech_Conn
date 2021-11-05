using System.Collections.Generic;

namespace Tech_Conn
{
    class MassInfoLine1
    {
        public string var1;
        public string var2;
        public string var3;
        public string var4;
        public string var5;
    }

    class Mass1
    {
        public List<MassInfoLine1> dataList;

        public Mass1()
        {
            dataList = new List<MassInfoLine1>();
        }
    }
}
