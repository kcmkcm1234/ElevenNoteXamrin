using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ElevenNote.Models;
using ElevenNote.Services;
using ElevenNote.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevenNote.Web.Tests.Controllers.NoteControllerTest
{

    [TestClass]
    class CreatePost : NoteControllerTestsBase  //ntctb tab will autofill
    {

       //Testing should return redirect to route result by calling method ourselves which we can then feed whatever parameters
        [TestMethod] //Tests are always void because we don't want to return anything
        public void ShouldReturnRedirectToRouteResult()
        {
            // ACT
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        private ActionResult Act()
        {
            return Controllers.Create(new NoteCreate());
        }

        [TestMethod]
        public void ShouldCallCreateOnce()
        {
            Act();

            // ASSERT
            Assert.AreEqual(1, Service.CreateNoteCallCount);



        }
    }
}
