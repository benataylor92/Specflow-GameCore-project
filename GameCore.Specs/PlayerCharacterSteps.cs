﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;

namespace GameCore.Specs
{
    [Binding]
    public class PlayerCharacterSteps
    {
        private PlayerCharacter _player;

        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            _player = new PlayerCharacter();
        }

        [When("I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _player.Hit(damage);
        }
        
        [Then(@"My health should be (.*)")]
        public void ThenMyHealthShouldBe(int expectedHealth)
        {
            Assert.Equal(expectedHealth, _player.Health);
        }

        [Then(@"I will be dead")]
        public void ThenIWillBeDead()
        {
            Assert.True(_player.IsDead);
        }
        [Given(@"I have a damage resistnace of (.*)")]
        public void GivenIHaveADamageResistnaceOf(int damageResistance)
        {
            _player.DamageResistance = damageResistance;
        }

        [Given(@"I'm an Elf")]
        public void GivenImAnElf()
        {
            _player.Race = "Elf";
        }

        [Given(@"I have the following attribute")]
        public void GivenIHaveTheFollowingAttribute(Table table)
        {
            //var race = table.Rows.First(row => row["attribute"] == "Race")["value"];
            //var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];

            //var attributes = table.CreateInstance<PlayerAttributes>();

            dynamic attributes = table.CreateDynamicInstance();

            _player.Race = attributes.Race;
            _player.DamageResistance = attributes.Resistance;
        }

        [Given(@"My character class is set to (.*)")]
        public void GivenMyCharacterClassIsSetToHealer(CharacterClass characterClass)
        {
            _player.CharacterClass = characterClass;
        }

        [When(@"Cast a healing spell")]
        public void WhenCastAHealingSpell()
        {
            _player.CastHealingSpell();
        }

    }
}
