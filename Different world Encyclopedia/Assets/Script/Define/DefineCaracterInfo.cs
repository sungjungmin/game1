﻿using System.Collections.Generic;
using UnityEngine;

namespace DefinitionChar
{
    public struct PlayerWeaponData
    {
        public float m_fWeaponAxisStart;
        public float m_fWeaponAxisEnd;

        public Vector2 m_v2WeaponColliderArea;
        public Vector2 m_v2Weaponoffset;

        public Vector2 m_v2WeaponPosition;

        public float m_fAttackSpeed;

        public bool isEnableWeaponHit;
    }

    public struct PlayerMoveData
    {
        public Vector2 m_v2CharacterColliderArea;

        public float m_fDashMoveWeight;
        public float m_fMoveWeight;

        public float m_fJumpForce;
        public int m_iJumpCount;
        public bool m_bIsBlink;

    }

    public class CharaterInfo
    {
        //for weapon
        public PlayerWeaponData m_sPlaerWeapon;
        //for PlayerMove
        public PlayerMoveData m_sPlayerMove;

        public CharaterInfo()
        {
            m_sPlaerWeapon = new PlayerWeaponData();
            m_sPlayerMove = new PlayerMoveData();
        }
    }

    public static class CustomCharacterInfo
    {
        public enum CHAR_TYPE
        {
            ALLIGATOR, //악어야
            MAGITION, // 마법사
            DRAGON, // 드래곤
            HERO //용사
        }

        //캐릭터는 7 Status 를 가지고 있음.
        //1. 사망 1순위
        //2. 피격 2순위
        //3. 점프 3순위
        //4. 공격 3순위
        //5. 이동 3순위
        //6. 대시 3순위
        //7. 스킬 3순위
        public enum CHAR_STATUS
        {
            NULL = 0, // 아무것도 안함.
            DEAD = 1, //피격
            HIT = 2, //사망
            JUMP = 4, //점프
            ATTACK = 8, // 공격
            MOVE = 16, //이동
            DASH_MOVE = 32, // 대시
            SKILL = 64 //스킬
        }

        public static Dictionary<CHAR_TYPE, CharaterInfo> CHAR_GLOBAL_DEFAULT_DATA;

        static CustomCharacterInfo()
        {
            CHAR_GLOBAL_DEFAULT_DATA = new Dictionary<CHAR_TYPE, CharaterInfo>();
            CHAR_GLOBAL_DEFAULT_DATA.Add(CHAR_TYPE.ALLIGATOR, generateDefaultCharInfo(CHAR_TYPE.ALLIGATOR));
            CHAR_GLOBAL_DEFAULT_DATA.Add(CHAR_TYPE.MAGITION, generateDefaultCharInfo(CHAR_TYPE.MAGITION));
            CHAR_GLOBAL_DEFAULT_DATA.Add(CHAR_TYPE.DRAGON, generateDefaultCharInfo(CHAR_TYPE.DRAGON));
            CHAR_GLOBAL_DEFAULT_DATA.Add(CHAR_TYPE.HERO, generateDefaultCharInfo(CHAR_TYPE.HERO));
        }
        
        private static CharaterInfo generateDefaultCharInfo(CHAR_TYPE arg)
        {
            CharaterInfo ret = new CharaterInfo();
            switch (arg)
            {
                case CHAR_TYPE.ALLIGATOR:
                    ret.m_sPlaerWeapon.m_fWeaponAxisStart = 30.0f;
                    ret.m_sPlaerWeapon.m_fWeaponAxisEnd = 130.0f;
                    ret.m_sPlaerWeapon.m_v2WeaponColliderArea = new Vector2(0.1f, 0.4f);
                    ret.m_sPlaerWeapon.m_v2Weaponoffset = new Vector2(0.0f, 0.0f);
                    ret.m_sPlaerWeapon.m_v2WeaponPosition = new Vector2(0.0f, 0.2f);
                    ret.m_sPlaerWeapon.m_fAttackSpeed = 0.40f;
                    ret.m_sPlaerWeapon.isEnableWeaponHit = true;

                    ret.m_sPlayerMove.m_v2CharacterColliderArea = new Vector2(0.45f, 0.58f);
                    ret.m_sPlayerMove.m_iJumpCount = 2;
                    ret.m_sPlayerMove.m_bIsBlink = false;
                    break;
                case CHAR_TYPE.MAGITION:
                    ret.m_sPlaerWeapon.m_fWeaponAxisStart = 0.0f;
                    ret.m_sPlaerWeapon.m_fWeaponAxisEnd = 45.0f;
                    ret.m_sPlaerWeapon.m_v2WeaponColliderArea = new Vector2(0.0f, 0.0f);
                    ret.m_sPlaerWeapon.m_v2Weaponoffset = new Vector2(0.0f, 0.0f);
                    ret.m_sPlaerWeapon.m_v2WeaponPosition = new Vector2(0.0f, 0.0f);
                    ret.m_sPlaerWeapon.m_fAttackSpeed = 1.2f;
                    ret.m_sPlaerWeapon.isEnableWeaponHit = false;

                    ret.m_sPlayerMove.m_v2CharacterColliderArea = new Vector2(0.45f, 0.70f);
                    ret.m_sPlayerMove.m_iJumpCount = 1;
                    ret.m_sPlayerMove.m_bIsBlink = false;
                    break;
                case CHAR_TYPE.DRAGON:
                    ret.m_sPlaerWeapon.m_fWeaponAxisStart = 0.0f;
                    ret.m_sPlaerWeapon.m_fWeaponAxisEnd = 130.0f;
                    ret.m_sPlaerWeapon.m_v2WeaponColliderArea = new Vector2(0.1f, 0.4f);
                    ret.m_sPlaerWeapon.m_v2Weaponoffset = new Vector2(0.0f, 0.0f);
                    ret.m_sPlaerWeapon.m_v2WeaponPosition = new Vector2(0.0f, 0.2f);
                    ret.m_sPlaerWeapon.m_fAttackSpeed = 0.6f;
                    ret.m_sPlaerWeapon.isEnableWeaponHit = true;

                    ret.m_sPlayerMove.m_v2CharacterColliderArea = new Vector2(0.45f, 0.70f);
                    ret.m_sPlayerMove.m_iJumpCount = 1;
                    ret.m_sPlayerMove.m_bIsBlink = true;
                    break;
                case CHAR_TYPE.HERO:
                    ret.m_sPlayerMove.m_v2CharacterColliderArea = new Vector2(0.45f, 0.70f);
                    break;
            }
            ret.m_sPlayerMove.m_fDashMoveWeight = 0.08f;
            ret.m_sPlayerMove.m_fMoveWeight = 0.04f;
            ret.m_sPlayerMove.m_fJumpForce = 400.0f;
            return ret;
        }

    }
}
