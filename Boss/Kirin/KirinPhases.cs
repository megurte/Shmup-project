﻿using System;
using System.Collections.Generic;
using Boss;
using UnityEngine;

namespace Kirin 
{
    public class KirinPhases : MonoBehaviour
    {
        public void InitPhaseOne(KirinSpellsAPI kirinSpells, KirinMove kirinPositions, List<SubListSpell> spells, List<SubListMove> moves)
        {
            GlobalEvents.OnPhaseChange.AddListener(OnPhaseChange);
            Debug.Log("Init " + Phases.PhaseOne);
            
            // SPELLS
            var currentPhaseSpells = spells[0];

            foreach (var currentSpell in currentPhaseSpells.list)
            {
                switch (currentSpell.spellName)
                {
                    case SpellName.Circle:
                        kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(currentSpell));
                        break;
                    case SpellName.SpiralWithDelay: 
                        kirinSpells.StartCoroutine(kirinSpells.SpiralSpellCast(currentSpell));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            // POSITIONS
            var currentPhaseMoves = moves[0];

            foreach (var currentMove in currentPhaseMoves.list)
            {
                kirinPositions.StartCoroutine(kirinPositions.MoveTo(currentMove));
            }
        }
        
        public void InitPhaseTwo(KirinSpellsAPI kirinSpells, KirinMove kirinPositions)
        {
            GlobalEvents.OnPhaseChange.AddListener(OnPhaseChange);
            Debug.Log("Init " + Phases.PhaseTwo);
            /*kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(2, true, kirinSpells.fireBullet, 70));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(3, true, kirinSpells.fireBullet, 80));
            kirinSpells.StartCoroutine(kirinSpells.RouletteSpellCastWithDelay(3.5f, true, kirinSpells.fireBullet, 70,0.001f));
            kirinSpells.StartCoroutine(kirinSpells.RouletteSpellCastWithDelay(4.5f, true, kirinSpells.fireBullet, 80,0.001f));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(5, true, kirinSpells.fireBullet, 70));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(5.5f, true, kirinSpells.fireBullet, 80));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(6, true, kirinSpells.fireBullet, 70));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(6.5f, true, kirinSpells.fireBullet, 80));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(7, false, kirinSpells.fireballSmall, 70));
            kirinSpells.StartCoroutine(kirinSpells.SpiralSpellCast(7.3f, true, kirinSpells.fireBullet, 100, 0.5f));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(8, true, kirinSpells.fireBullet, 26));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(8.5f, true, kirinSpells.fireball, 80));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(9, false, kirinSpells.fireball, 60));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(9.5f, true, kirinSpells.timedFireball, 32));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(10, false, kirinSpells.timedFireball, 70));
            
            // POSITIONS
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(2, kirinPositions.position0));
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(5, kirinPositions.position1));
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(7, kirinPositions.position2));
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(9, kirinPositions.position3));*/
            
        }
        
        public void InitPhaseThree(KirinSpellsAPI kirinSpells, KirinMove kirinPositions)
        {
            GlobalEvents.OnPhaseChange.AddListener(OnPhaseChange);
            Debug.Log("Init " + Phases.PhaseThree);
            /*kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(2, true, kirinSpells.fireBullet, 70));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(3, true, kirinSpells.fireBullet, 80));
            kirinSpells.StartCoroutine(kirinSpells.RouletteSpellCastWithDelay(3.5f, true, kirinSpells.fireBullet, 70,0.001f));
            kirinSpells.StartCoroutine(kirinSpells.RouletteSpellCastWithDelay(4.5f, true, kirinSpells.fireBullet, 80,0.001f));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(5, true, kirinSpells.fireBullet, 70));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(5.5f, true, kirinSpells.fireBullet, 80));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(6, true, kirinSpells.fireBullet, 70));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(6.5f, true, kirinSpells.fireBullet, 80));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(7, false, kirinSpells.fireballSmall, 70));
            kirinSpells.StartCoroutine(kirinSpells.SpiralSpellCast(7.3f, true, kirinSpells.fireBullet, 100, 0.5f));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(8, true, kirinSpells.fireBullet, 26));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(8.5f, true, kirinSpells.fireball, 80));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(9, false, kirinSpells.fireball, 60));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(9.5f, true, kirinSpells.timedFireball, 32));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(10, false, kirinSpells.timedFireball, 70));*/
            
            // POSITIONS
            /*kirinPositions.StartCoroutine(kirinPositions.MoveTo(2, kirinPositions.position0));
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(5, kirinPositions.position1));
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(7, kirinPositions.position2));
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(9, kirinPositions.position3));*/

        }
        
        public void InitPhaseFour(KirinSpellsAPI kirinSpells, KirinMove kirinPositions)
        {
            GlobalEvents.OnPhaseChange.AddListener(OnPhaseChange);
            Debug.Log("Init " + Phases.PhaseFour);
            /*kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(2, true, kirinSpells.fireBullet, 70));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(3, true, kirinSpells.fireBullet, 80));
            kirinSpells.StartCoroutine(kirinSpells.RouletteSpellCastWithDelay(3.5f, true, kirinSpells.fireBullet, 70,0.001f));
            kirinSpells.StartCoroutine(kirinSpells.RouletteSpellCastWithDelay(4.5f, true, kirinSpells.fireBullet, 80,0.001f));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(5, true, kirinSpells.fireBullet, 70));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(5.5f, true, kirinSpells.fireBullet, 80));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(6, true, kirinSpells.fireBullet, 70));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(6.5f, true, kirinSpells.fireBullet, 80));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(7, false, kirinSpells.fireballSmall, 70));
            kirinSpells.StartCoroutine(kirinSpells.SpiralSpellCast(7.3f, true, kirinSpells.fireBullet, 100, 0.5f));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(8, true, kirinSpells.fireBullet, 26));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(8.5f, true, kirinSpells.fireball, 80));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(9, false, kirinSpells.fireball, 60));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(9.5f, true, kirinSpells.timedFireball, 32));
            kirinSpells.StartCoroutine(kirinSpells.CircleSpellCast(10, false, kirinSpells.timedFireball, 70));*/
            
            // POSITIONS
            /*kirinPositions.StartCoroutine(kirinPositions.MoveTo(2, kirinPositions.position0));
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(5, kirinPositions.position1));
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(7, kirinPositions.position2));
            kirinPositions.StartCoroutine(kirinPositions.MoveTo(9, kirinPositions.position3));*/
        }

        private void OnPhaseChange(int phase)
        {
            StopAllCoroutines();
        }
    }
}