﻿using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    internal class ComplexTests
    {
        [Test]
        public void BoldAndCursiveItersect()
        {
            Markdown.Markdown.Render("Text _with __text_ and__")
                .Should().Be(@"Text _with __text_ and__");

            Markdown.Markdown.Render("_a __b c_ d _e f__ g_")
                .Should().Be(@"_a __b c_ d _e f__ g_");

            Markdown.Markdown.Render("_a b__ c_ d _e f__ g_ _abcd_ _a __b c_ d__")
                .Should().Be(@"_a b__ c_ d _e f__ g_ <em>abcd<\em> _a __b c_ d__");

            Markdown.Markdown.Render("_a __b c_ d _e f__ g __h i_ j__")
                .Should().Be(@"_a __b c_ d _e f__ g __h i_ j__");

            Markdown.Markdown.Render("_a __b__ __c d_ e f__")
                .Should().Be(@"_a <strong>b<\strong> __c d_ e f__");
        }

        [Test]
        public void BoldInCursive()
        {
            Markdown.Markdown.Render("Text _with __text__ and_")
                .Should().Be(@"Text <em>with __text__ and<\em>");
        }

        [Test]
        public void CursiveInBold()
        {
            Markdown.Markdown.Render("Text __with _text_ and__")
                .Should().Be(@"Text <strong>with <em>text<\em> and<\strong>");
        }
    }
}