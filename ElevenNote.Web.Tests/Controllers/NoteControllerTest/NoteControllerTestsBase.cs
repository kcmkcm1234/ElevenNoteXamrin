using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevenNote.Services;
using ElevenNote.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevenNote.Web.Tests.Controllers.NoteControllerTest
{


    //create new controllers for every test to really isolate testing
    [TestClass]
    public abstract class NoteControllerTestsBase //'abstract' because all we are going to do is inherit it - going to put implementation on it. 
    {
        protected NoteController Controllers; //'protected' allows access to only base class and inheritors (just less than private)

        protected FakeNoteService Service;

        //ARRANGE
        //ACT
        //ASSERT

        [TestInitialize] //prepares it before each(every) test
        public virtual void Arrange()
        {

            Service = new FakeNoteService();

            Controllers = new NoteController( //Controller. lists options
            new Lazy<INoteService>());
        }




    }
}
