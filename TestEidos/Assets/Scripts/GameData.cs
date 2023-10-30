using System;
using UnityEngine;

[Serializable]
public class GameData
{
    [Serializable]
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [Serializable]
    public struct Vec4
    {
        public float r, g, b, a;

        public Vec4(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }

    [Serializable]
    public struct CharacterSaveDataRotation
    {
        public Vec3 eye, head, body;

        public CharacterSaveDataRotation(Vec3 eye, Vec3 head, Vec3 body)
        {
            this.eye = eye;
            this.head = head;
            this.body = body;
        }
    }

    [Serializable]
    public struct ColorSaveData
    {
        public Vec4 eyeColor, headColor, bodyColor;

        public ColorSaveData(Vec4 eye, Vec4 head, Vec4 body)
        {
            eyeColor = eye;
            headColor = head;
            bodyColor = body;
        }
    }

    public CharacterSaveDataRotation playerRotation;
    public ColorSaveData playerColor;

    public void SaveRotation(CharacterRotation player)
    {
        Vec3 eyeRotation = new Vec3(player.Eye.transform.rotation.x, player.Eye.transform.rotation.y, player.Eye.transform.rotation.z);
        Vec3 headRotation = new Vec3(player.Head.transform.rotation.x, player.Head.transform.rotation.y, player.Head.transform.rotation.z);
        Vec3 bodyRotation = new Vec3(player.Body.transform.rotation.x, player.Body.transform.rotation.y, player.Body.transform.rotation.z);

        playerRotation = new CharacterSaveDataRotation(eyeRotation, headRotation, bodyRotation);
    }

    public void SaveColor(ColorChanger colorChanger)
    {
        Vec4 eyeColor = new Vec4(colorChanger.EyeColor.r, colorChanger.EyeColor.g, colorChanger.EyeColor.b, colorChanger.EyeColor.a);
        Vec4 headColor = new Vec4(colorChanger.HeadColor.r, colorChanger.HeadColor.g, colorChanger.HeadColor.b, colorChanger.HeadColor.a);
        Vec4 bodyColor = new Vec4(colorChanger.BodyColor.r, colorChanger.BodyColor.g, colorChanger.BodyColor.b, colorChanger.BodyColor.a);

        playerColor = new ColorSaveData(eyeColor, headColor, bodyColor);
    }
}
