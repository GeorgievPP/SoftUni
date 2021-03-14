//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 50;
            int expectedHp = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHp);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHp, actualHp);
        }

        [Test]
        public void TestWithNullForName()
        {
            string name = null;
            int damage = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]

        public void TestWithEmptyName()
        {
            string name = String.Empty;
            int damage = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void TestWithWhiteSpaceForName()
        {
            string name = "            ";
            int damage = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void TestWithZeroDamage()
        {
            string name = "Pesho";
            int damage = 0;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void TestWithNegativeDamage()
        {
            string name = "Gosho";
            int damage = -50;
            int hp = 50;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void TestWithNegativeHP()
        {
            string name = "Pesho";
            int damage = 50;
            int hp = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWhenLowHpShouldReturnException(int attackerHP)
        {
            string attackerName = "Pesho";
            int attackerDmg = 30;

            string enemyName = "Gosho";
            int enemyDmg = 30;
            int enemyHp = 40;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior enemy = new Warrior(enemyName, enemyDmg, enemyHp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(enemy);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackingEnemyWhenLowHpShouldThrowException(int enemyHP)
        {
            string attackerName = "Pesho";
            int attackerDmg = 30;
            int attackerHP = 100;

            string enemyName = "Gosho";
            int enemyDmg = 30;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior deffender = new Warrior(enemyName, enemyDmg, enemyHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void AttackingStrongerEnemyShouldThrowException()
        {
            string aNmae = "Pesho";
            int aDmg = 10;
            int aHP = 35;

            string dName = "Gosho";
            int dDmg = 40;
            int dHP = 35;

            Warrior attacker = new Warrior(aNmae, aDmg, aHP);
            Warrior deffender = new Warrior(dName, dDmg, dHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(deffender);
            });
        }

        [Test]
        public void AttackingShouldDecreaseHPWhenSuccessufull()
        {
            //Arrange
            string aNmae = "Pesho";
            int aDmg = 10;
            int aHP = 40;

            string dName = "Gosho";
            int dDmg = 5;
            int dHP = 40;

            Warrior attacker = new Warrior(aNmae, aDmg, aHP);
            Warrior deffender = new Warrior(dName, dDmg, dHP);

            int expectedAttackerHP = aHP - dDmg;
            int expectedDeffenderHP = dHP - aDmg; ;

            //Act
            attacker.Attack(deffender);

            //Assert
            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDeffenderHP, deffender.HP);
        }

        [Test]
        public void TestKillingEnemyWithAttack()
        {
            //Arrange
            string aNmae = "Pesho";
            int aDmg = 80;
            int aHP = 100;

            string dName = "Gosho";
            int dDmg = 10;
            int dHP = 60;

            Warrior attacker = new Warrior(aNmae, aDmg, aHP);
            Warrior deffender = new Warrior(dName, dDmg, dHP);

            int expectedAttackerHP = aHP - dDmg;
            int expectedDeffenderHP = 0;

            //Act
            attacker.Attack(deffender);

            //Assert
            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDeffenderHP, deffender.HP);
        }
    }
}