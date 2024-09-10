using FluentAssertions;
using TillBuddy.SDK.Model;
using TillBuddy.SDK.Model.Exceptions;

namespace TillBuddy.Models.Tests;

public class EmailTests
{
    [Theory]
    [InlineData("james@bond.com")]
    [InlineData("another.person@email.no")]
    [InlineData("Some.Other.Email@Email.COM")]
    public void Emails_should_work(string emailAddress)
    {
        var email = EmailAddress.Parse(emailAddress);
        
        email.Should().NotBeNull();

        email.Should().BeOfType<EmailAddress>();
        
        email.ToString().Should().BeSameAs(emailAddress);
    }

    [Theory]
    [InlineData("@bond.com")]
    [InlineData("email")]
    public void Emails_should_fail(string emailAddress)
    {
        Action act = () => EmailAddress.Parse(emailAddress);

        act.Should().Throw<EmailAddressArgumentFormatException>();
    }


    [Theory]
    [InlineData("person1@email.com", "person1@email.com")]
    [InlineData("person1@Email.com", "person1@email.com")]
    [InlineData("person3.test1@email.com", "person3.test1@email.com")]
    public void Emails_should_be_equal(string emailAddress1, string emailAddress2)
    {
        var e1 = EmailAddress.Parse(emailAddress1);
        var e2 = EmailAddress.Parse(emailAddress2);

        e1.Should().NotBeNull();
        e2.Should().NotBeNull();

        e1.Should().BeEquivalentTo(e2);
    }
}

