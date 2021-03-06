﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace NGeo.GeoNames
{
    [TestClass]
    public class PostalCodeResultsTests
    {
        [TestMethod]
        public void GeoNames_PostalCodeResults_ShouldBePublic()
        {
            var model = new PostalCodeResults
            {
                Items = new List<PostalCode>
                {
                    new PostalCode(), new PostalCode(), new PostalCode(),
                },
            };

            model.ShouldNotBeNull();
            model.Items.ShouldNotBeNull();
            model.Items.Count.ShouldEqual(3);
        }

        [TestMethod]
        public void GeoNames_PostalCodeResults_ShouldImplementGenericIEnumerable()
        {
            var model = new PostalCodeResults
            {
                Items = new List<PostalCode>
                {
                    new PostalCode(), new PostalCode(), new PostalCode(),
                },
            };

            model.ShouldImplement(typeof(IEnumerable<PostalCode>));
            model.GetEnumerator().ShouldNotBeNull();
            ((IEnumerable)model).GetEnumerator().ShouldNotBeNull();
            foreach (var item in model)
            {
                item.ShouldNotBeNull();
            }
        }

        [TestMethod]
        public void GeoNames_PostalCodeResults_ShouldHaveDataContractAttribute()
        {
            Attribute.IsDefined(typeof(PostalCodeResults), typeof(DataContractAttribute))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void GeoNames_PostalCodeResults_Items_ShouldHaveDataMemberAttribute()
        {
            var genericListProperties = new Dictionary<string, Expression<Func<PostalCodeResults, List<PostalCode>>>>
            {
                { "postalcodes", p => p.Items },
            };

            genericListProperties.ShouldHaveDataMemberAttributes();
        }

    }
}
