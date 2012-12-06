using Blog.Core.Domain;
using Blog.Core.Extensions;
using SharpTestsEx;
using Xunit;

namespace Blog.Core.Tests.Extensions
{
    public class ObjectExtensionsTests
    {
        public class UserExtensionTests
        {
            [Fact]
            public void Gets_full_name_from_user()
            {
                var user = new User
                {
                    FirstName = "John",
                    LastName = "Doe"
                };

                user.FullName()
                    .Should()
                    .Be("John Doe");
            }

            [Fact]
            public void Unknown_name_for_missing_user()
            {
                User user = null;

                user.FullName()
                    .Should()
                    .Be("Unknown");
            }
        }

        public class PagingTests
        {
            [Fact]
            public void Correct_page_number_per_items_per_page_when_total_items_greater_than_items_per_page()
            {
                const long items = 20L;

                items.TotalPages(5)
                    .Should()
                    .Be(4);
            }

            [Fact]
            public void Correct_page_number_when_items_less_than_items_per_page()
            {
                const long items = 4L;

                items.TotalPages(5)
                    .Should()
                    .Be(1);
            }
        }
    }
}