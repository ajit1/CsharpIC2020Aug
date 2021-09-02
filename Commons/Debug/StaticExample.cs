using NUnit.Framework;

namespace Commons.Debug
{
    class StaticExample
    {

        [Test]
        public void Testing()
        {
            IC obj1 = new IC();
            obj1.name = "Temp";
            TestContext.WriteLine(obj1.name); //Temp
            obj1.name = "Temp1";

            IC obj2 = new IC();
            TestContext.WriteLine(obj2.name);

            //How many object ----------- TWo 


            //no object  //Static is friend of class 
            TestContext.WriteLine(IC.nameS);

            TestContext.WriteLine(IC.nameS);

            TestContext.WriteLine(IC.nameS);

            TestContext.WriteLine(IC.nameS);

            TestContext.WriteLine(IC.nameS);

            //abc .. Testing Testing Tesing
        }

    }


    class IC
    {
        //non static
        public string name = "abc";

        //static
        public readonly static string nameS = "abc_static";

        public IC()
        {
            TestContext.WriteLine("Create object");
        }



    }
}
