﻿using Newtonsoft.Json;
using Valetude.Rollbar;
using Xunit;

namespace Rollbar.Test {
    public class RollbarPersonFixture {
        [Fact]
        public void Person_id_rendered_correctly() {
            var rp = new RollbarPerson("person_id");
            Assert.Equal("{\"id\":\"person_id\"}", JsonConvert.SerializeObject(rp));
        }

        [Fact]
        public void Person_username_rendered_correctly() {
            var rp = new RollbarPerson("person_id") {
                UserName = "chris_pfohl",
            };
            Assert.Equal("{\"id\":\"person_id\",\"username\":\"chris_pfohl\"}", JsonConvert.SerializeObject(rp));
        }

        [Fact]
        public void Person_email_rendered_correctly() {
            var rp = new RollbarPerson("person_id") {
                Email = "chris@valetude.com",
            };
            Assert.Equal("{\"id\":\"person_id\",\"email\":\"chris@valetude.com\"}", JsonConvert.SerializeObject(rp));
        }
    }
}
