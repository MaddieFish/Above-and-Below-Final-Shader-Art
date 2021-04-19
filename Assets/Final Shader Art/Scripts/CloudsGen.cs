//Reference: Unity Procedural Clouds Shader Tutorial by Decompiled Art

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CloudsGen : MonoBehaviour
{
    public int cloudsResolution = 20;
    public float cloudHeight;
    public Mesh cloudMesh;
    public Material cloudMaterial;
    private float _offset;
    public Camera _sceneCamera;
    private Matrix4x4 _cloudsPosMatrix;
    public bool shadowCasting, shadowRecieve, useLightProbes;
    private void OnEnable()
    {
        _sceneCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var currentTransform = transform;
        cloudMaterial.SetFloat("CloudsWorldPos", currentTransform.position.y);
        cloudMaterial.SetFloat("CloudHeight", cloudHeight);
        _offset = cloudHeight / cloudsResolution / 2f;
        var initPos = transform.position + (Vector3.up * (_offset * cloudsResolution/2f));
        for (var i = 0; i < cloudsResolution; i++)
        {
            //take into consideration translation, rotation, scale of clouds-gen object
            _cloudsPosMatrix = Matrix4x4.TRS(initPos - (Vector3.up * _offset * i),currentTransform.rotation, currentTransform.localScale);

            //push mesh data to render without editor overhead or managing multiple objects
            Graphics.DrawMesh(cloudMesh, _cloudsPosMatrix, cloudMaterial, 0, _sceneCamera, 0, null, shadowCasting, shadowRecieve, useLightProbes);

        }
    }
}
