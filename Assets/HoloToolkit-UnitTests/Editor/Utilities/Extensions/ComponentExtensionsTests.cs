﻿using NUnit.Framework;
using UnityEngine;

namespace HoloToolkit.Unity.Tests
{
    public class ComponentExtensionsTests
    {
        [SetUp]
        public void ClearScene()
        {
            TestUtils.ClearScene();
        }

        [Test]
        public void EnsureComponentNotNull()
        {
            var gameObject = new GameObject();
            gameObject.EnsureComponent<BoxCollider>();
            Assert.That(gameObject.GetComponent<BoxCollider>() == null, Is.False);
        }

        [Test]
        public void EnsureOnlyOneComponentWithExisting()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent<BoxCollider>();
            gameObject.EnsureComponent<BoxCollider>();
            Assert.That(gameObject.GetComponents<BoxCollider>().Length, Is.EqualTo(1));
        }

        [Test]
        public void EnsureReturnsSameComponentWithExisting()
        {
            var gameObject = new GameObject();
            var existingComponent = gameObject.AddComponent<BoxCollider>();
            var ensuredComponent = gameObject.EnsureComponent<BoxCollider>();
            Assert.That(ensuredComponent, Is.EqualTo(existingComponent));
        }

        [Test]
        public void EnsureComponentOnComponent()
        {
            var gameObject = new GameObject();
            var existingComponent = gameObject.AddComponent<BoxCollider>();
            var ensuredComponent = existingComponent.EnsureComponent<SphereCollider>();
            Assert.That(ensuredComponent == null, Is.False);
        }
    }
}
