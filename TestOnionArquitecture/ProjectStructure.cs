using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnionArchitecture.Class;

namespace TestOnionArquitecture
{
    [TestClass]
    public class ProjectStructure
    {
        [TestMethod]
        public void CreateProjectStructure()
        {
            //ARRANGE

            ProjectInfo objProject = new ProjectInfo();
            StructureCreation objCreateStructure = new StructureCreation();
            
            objProject.Name = "TestProject";


            //ACT




            //ASSERT

            Assert.IsTrue(objCreateStructure.Created);



        }
    }
}
