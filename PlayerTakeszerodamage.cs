using TechTalk.SpecFlow;
using Xunit;

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
        
        [When(@"I take 0 damage")]
        public void WhenITake0Damage()
        {
            _player.Hit(0);
        }
        
        [Then(@"My health should be 1000")]
        public void ThenMyHealthShouldBe1000()
        {
            Assert.Equal(1000, _player.Health);
        }
    }
}
