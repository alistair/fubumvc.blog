using Blog.Core.Extensions;
using SharpTestsEx;
using Xunit;

namespace Blog.Core.Tests.Extensions
{
    public class MapperExtensionsTests
    {
        [Fact]
        public void Maps_two_types_dynamicly()
        {
            var type = new Type1
            {
                Text = "Test"
            };

            var mappedType = type.DynamicMap<Type2>();

            mappedType.Should().Be.OfType<Type2>();
            mappedType.Text.Should().Be(type.Text);
        }

        [Fact]
        public void Does_not_map_or_throw_if_two_different_types_map_dynamicly()
        {
            var type = new Type1
            {
                Text = "Test"
            };

            var mappedType = type.DynamicMap<Type3>();

            mappedType.Should().Be.OfType<Type3>();
            mappedType.Number.Should().Be(0);
        }

        [Fact]
        public void Dynamicly_maps_null_to_null()
        {
            Type1 type = null;

            Type3 mappedType = type.DynamicMap<Type3>();

            mappedType.Should().Be.Null();
        }


        private class Type1
        {
            public string Text { get; set; }
        }

        private class Type2
        {
            public string Text { get; set; }
        }

        private class Type3
        {
            public int Number { get; set; }
        }
    }
}