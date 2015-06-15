﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Rollbar.Test {
    public class RollbarBodyFixture {
        [Fact]
        public void Crash_report_works_correctly() {
            var rollbarBody = new RollbarBody("Crash happened");
            var json = JsonConvert.SerializeObject(rollbarBody);
            Assert.Equal("{\"crash_report\":{\"raw\":\"Crash happened\"}}", json);
            Assert.DoesNotContain("\"trace\":{", json);
            Assert.DoesNotContain("\"trace_chain\":{", json);
            Assert.DoesNotContain("\"message\":{", json);
        }

        [Fact]
        public void Message_works_correctly() {
            var rollbarBody = new RollbarBody(new RollbarMessage("Body of the message") {
                {"key", "value"}
            });
            var json = JsonConvert.SerializeObject(rollbarBody);
            Assert.Contains("{\"message\":{", json);
            Assert.Contains("\"Body of the message\"", json);
            Assert.Contains("\"key\":\"value\"", json);
            Assert.DoesNotContain("\"trace\":{", json);
            Assert.DoesNotContain("\"trace_chain\":{", json);
            Assert.DoesNotContain("\"crash_report\":{", json);
        }

        [Fact]
        public void Trace_works_correctly() {
            var rollbarBody = new RollbarBody(GetException());
            var json = JsonConvert.SerializeObject(rollbarBody);
            Assert.Contains("\"trace\":{", json);
            Assert.Contains("\"Rollbar.Test.RollbarBodyFixture.GetException()\"", json);
            Assert.DoesNotContain("\"crash_report\":{", json);
            Assert.DoesNotContain("\"trace_chain\":{", json);
            Assert.DoesNotContain("\"message\":{", json);
        }

        [Fact]
        public void Trace_chain_works_correctly() {
            var rollbarBody = new RollbarBody(GetAggregateException());
            var json = JsonConvert.SerializeObject(rollbarBody);
            Assert.Contains("\"trace_chain\":[", json);
            Assert.Contains("\"Rollbar.Test.RollbarBodyFixture.ThrowException()\"", json);
            Assert.DoesNotContain("\"crash_report\":{", json);
            Assert.DoesNotContain("\"trace\":{", json);
            Assert.DoesNotContain("\"message\":{", json);
        }

        private static AggregateException GetAggregateException() {
            try {
                Parallel.ForEach(new[] { 1, 2 }, i => ThrowException());
            }
            catch (AggregateException e) {
                return e;
            }
            throw new Exception("Unreachable");
        }

        private static Exception GetException() {
            try {
                ThrowException();
            }
            catch (Exception e) {
                return e;
            }
            throw new Exception("Unreachable");
        }

        private static void ThrowException() {
            throw new Exception("Oops");
        }
    }
}
