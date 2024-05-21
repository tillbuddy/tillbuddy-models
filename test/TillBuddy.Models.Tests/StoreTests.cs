using TillBuddy.Models;

namespace Tests
{
    public class StoreTests
    {

        public static IEnumerable<object[]> ValidJson()
        {
            return new TheoryData<string>
        {
            """
            {
                "PhysicalAddress" : {
                    "AddressLine" : "street 1",
                    "City" : "OSLO",
                    "PostalCode" : "0250",
                    "Country" : "NO",
                    "Coordinates" : null
                },
                "ContactAddress" : {
                    "AddressLine" : "street 1",
                    "City" : "OSLO",
                    "PostalCode" : "0250",
                    "Country" : "NO",
                    "Coordinates" : null
                },
                "Phone" : "111111111",
                "Email" : "test@test.com"
            }
            """,
            """
            {
                "PhysicalAddress" : {
                    "AddressLine" : "Stirling Agricultural Centre",
                    "City" : "Stirling",
                    "PostalCode" : "FK94RN",
                    "Country" : "UK",
                    "Location" : null,
                    "Coordinates" : "56.1418737350271, -3.9868177863974656"
                },
                "ContactAddress" : {
                    "AddressLine" : "Stirling Agricultural Centre",
                    "City" : "Stirling",
                    "PostalCode" : "FK94RN",
                    "Country" : "UK",
                    "Location" : null,
                    "Coordinates" : "56.1418737350271, -3.9868177863974656"
                },
                "Phone" : "+44 (0)1786 471 586",
                "Email" : "enquiriesuk@sundolitt.com"
            }
            """
        };
        }

        [Theory, MemberData(nameof(ValidJson))]
        public void ParseJson(string value)
        {
            var store = System.Text.Json.JsonSerializer.Deserialize<StoreContactInformation>(value);
        }


        [Theory, MemberData(nameof(ValidJson))]
        public void Map_to_response(string value)
        {
            var store = System.Text.Json.JsonSerializer.Deserialize<StoreContactInformation>(value);


            store.MapToResponse();
        }
    }
}
