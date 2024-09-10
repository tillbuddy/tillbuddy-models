using FluentAssertions;
using System.Text.Json;
using TillBuddy.SDK.Model;

namespace TillBuddy.Models.Tests;

public class LocalizedTextTests// : IClassFixture<JsonOptionFixture>
{
    [Fact]
    public void Parser_should_handle_empty_object()
    {
        var json = """
        { 
        }
        """;

        var localizedText = JsonSerializer.Deserialize<LocalizedText>(json);

        Assert.NotNull(localizedText);
        Assert.Equal("", localizedText.Text);
        Assert.Equal("", localizedText["en"]);
        Assert.Equal("", localizedText["no"]);
        Assert.False(localizedText.UseTranslation);
    }

    [Fact]
    public void Parser_should_handle_all_null_values()
    {
        var json = """
        { 
            "text": null,
            "useTranslation": false,
            "translations": null
        }
        """;

        var localizedText = JsonSerializer.Deserialize<LocalizedText>(json);

        Assert.NotNull(localizedText);
        Assert.Equal("", localizedText.Text);
        Assert.Equal("", localizedText["en"]);
        Assert.Equal("", localizedText["no"]);
        Assert.False(localizedText.UseTranslation);
    }

    [Fact]
    public void Parser_should_handle_null_values()
    {
        var json = """
        { 
            "text": null,
            "useTranslation": false,
            "translations": null
        }
        """;

        var localizedText = JsonSerializer.Deserialize<LocalizedText>(json);

        Assert.NotNull(localizedText);
        Assert.Equal("", localizedText.Text);
        Assert.Equal("", localizedText["en"]);
        Assert.Equal("", localizedText["no"]);
        Assert.False(localizedText.UseTranslation);
    }

    [Fact]
    public void Should_be_able_to_create_from_json()
    {
        var json = """
        { 
            "text": "Some text",
            "useTranslation": true,
            "translations": {
                "en": "English text",
                "no": "Norwegian text"
            }
        }
        """;

        var localizedText = JsonSerializer.Deserialize<LocalizedText>(json);

        Assert.NotNull(localizedText);
        Assert.Equal("Some text", localizedText.Text);
        Assert.Equal("English text", localizedText["en"]);
        Assert.Equal("Norwegian text", localizedText["no"]);
        Assert.True(localizedText.UseTranslation);
    }

    [Fact]
    public void Should_be_able_to_create_from_json2()
    {
        var json = """
        { 
            "text": "Some text"            
        }
        """;

        var localizedText = JsonSerializer.Deserialize<LocalizedText>(json);

        Assert.NotNull(localizedText);
        Assert.Equal("Some text", localizedText.Text);
        Assert.False(localizedText.UseTranslation);
    }

    [Fact]
    public void Should_be_able_to_create_from_json3()
    {
        var json = """
        { 
            "translations": {
                "en": "English text",
                "no": "Norwegian text"
            }
        }
        """;

        var localizedText = JsonSerializer.Deserialize<LocalizedText>(json);

        Assert.NotNull(localizedText);
        Assert.True(localizedText.UseTranslation);
        Assert.Equal("English text", localizedText["en"]);
    }

    [Fact]
    public void Should_be_able_to_create()
    {
        var localizedText = new LocalizedText();

        Assert.NotNull(localizedText);

        localizedText = new LocalizedText("Some text");

        Assert.NotNull(localizedText);

        localizedText = new LocalizedText(new Dictionary<string, string> { { "en", "English text" } });

        Assert.NotNull(localizedText);
    }

    [Theory]
    [InlineData("Text 1")]
    [InlineData("Text 2")]
    [InlineData("")]
    [InlineData("A very long text should be no problem to store! Also with special sign !!=)/)(!&(%/(&%!(&/!)/!)=&!()/!%&/())=/()/(&)=/(=)/)(/&)(/)/(%&/(&)=(")]
    public void Should_be_able_to_create_with_different_texts(string text)
    {
        var localizedText = new LocalizedText(text);

        Assert.NotNull(localizedText);
    }

    [Theory]
    [InlineData("en", "no", "se", "dk")]
    public void Should_be_able_to_create_with_different_languages(string en, string no, string se, string dk)
    {
        var localizedText = new LocalizedText(new Dictionary<string, string> { { "en", en }, { "no", no }, { "se", se }, { "dk", dk } });

        Assert.NotNull(localizedText);
        Assert.Equal("en", localizedText["en"]);
        Assert.Equal("no", localizedText["no"]);
        Assert.Equal("se", localizedText["se"]);
        Assert.Equal("dk", localizedText["dk"]);
    }

    [Theory]
    [InlineData("en", "no", "se", "dk")]
    [InlineData("en", "it", "se", "dk")]
    public void Should_not_fail_if_asking_for_wrong_language(string en, string no, string se, string dk)
    {
        var localizedText = new LocalizedText(new Dictionary<string, string> { { "en", en }, { "no", no }, { "se", se }, { "dk", dk } });

        Assert.NotNull(localizedText);
        Assert.Equal("", localizedText["fi"]);
    }

    [Fact]
    public void Populate_should_work()
    {
        var localizedText = new LocalizedText()
        {
            Text = "text",
            Translations = { { "en", "en" } },
            UseTranslation = true
        };

        var targetLocalizedText = new LocalizedText();

        targetLocalizedText.Populate(localizedText);

        Assert.NotNull(targetLocalizedText);
        Assert.Equal("en", targetLocalizedText["en"]);
        Assert.Equal("text", targetLocalizedText.Text);

        Assert.NotSame(localizedText, targetLocalizedText);
        Assert.NotSame(localizedText.Translations, targetLocalizedText.Translations);
    }

    [Fact]
    public void Equal_operator_should_work()
    {
        var l1 = new LocalizedText()
        {
            Text = "text",
            Translations = { { "en", "en" }, { "no", "no" } },
            UseTranslation = true
        };

        var l2 = new LocalizedText()
        {
            Text = "text",
            Translations = { { "en", "en" }, { "no", "no" } },
            UseTranslation = true
        };

        Assert.Equal(l1, l2);
    }

    [Fact]
    public void Equal_operator_should_work_with_different_order_on_translations()
    {
        var l1 = new LocalizedText()
        {
            Text = "text",
            Translations = { { "no", "no" }, { "en", "en" } },
            UseTranslation = true
        };

        var l2 = new LocalizedText()
        {
            Text = "text",
            Translations = { { "en", "en" }, { "no", "no" } },
            UseTranslation = true
        };

        Assert.Equal(l1, l2);
    }

    [Fact]
    public void NotEqual_operator_should_work()
    {
        var l1 = new LocalizedText()
        {
            Text = "text",
            Translations = { { "en", "1" }, { "no", "2" } },
            UseTranslation = true
        };

        var l2 = new LocalizedText()
        {
            Text = "text",
            Translations = { { "en", "en" }, { "no", "no" } },
            UseTranslation = true
        };

        Assert.NotEqual(l1, l2);
    }

    [Fact]
    public void Clone_should_work()
    {
        var localizedText = new LocalizedText()
        {
            Text = "text",
            Translations = { { "en", "en" } },
            UseTranslation = true
        };

        var targetLocalizedText = (LocalizedText)localizedText.Clone();

        Assert.NotNull(targetLocalizedText);
        Assert.Equal("en", targetLocalizedText["en"]);
        Assert.Equal("text", targetLocalizedText.Text);

        Assert.NotSame(localizedText, targetLocalizedText);
        Assert.NotSame(localizedText.Translations, targetLocalizedText.Translations);
    }

    [Fact]
    public void Implicit_operator_should_set_correct_values()
    {
        var text = Guid.NewGuid().ToString();

        LocalizedText localizedText = text;

        localizedText.Text.Should().Be(text);

    }

    [Fact]
    public void Converting_to_string_should_work()
    {
        var text = new LocalizedText("A");

        string a = text;
        
        text = null;

        string? b = text;

        a.Should().Be("A");
        b.Should().BeNull();
    }

    [Fact]
    public void Converting_from_string_should_work()
    {
        LocalizedText localizedText = "A";

        localizedText.Text.Should().Be("A");
    }
}