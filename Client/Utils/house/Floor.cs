using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public int index = 0;
    [Label("柜子")]
    public Collider cupboard;
    [Label("柜子挂点")]
    public Transform[] points = new Transform[3];
    [Label("楼层碰撞盒")]
    public Collider self;
    [Label("添加图标")]
    public GameObject addIcon;
    [Label("楼层被锁标志位")]
    public GameObject disableMark;
    [Label("角色位置绑点")]
    public Transform rollPosition;
    RoomPet rp;

#if !ART_PROJECT

    GameObjectEX[] eqs = null;
    public enum RoleActionType
    {
        STAND,//站立
        WALK,//行走
    }

    public RoleActionType action = RoleActionType.STAND;
    public float actionTime = 5f;

    Vector3 rolePosition0 = Vector3.zero;
    Vector3 rolePosition1 = Vector3.zero;
    Vector3 standPosition;
    float walkSpeed = 1f;
    private void Start()
    {
        if (null != rollPosition)
        {
            rolePosition0 = rollPosition.position;
            if (rollPosition.childCount > 0)
            {
                rolePosition1 = rollPosition.GetChild(0).position;
            }
            else
            {
                rolePosition1 = rolePosition0 + Vector3.right * 5f;
            }
        }
    }
    bool enable = false;
    public bool isActive()
    {
        return enable;
    }
    public void SetEnable(bool b)
    {
        enable = b;
        if (b)
        {
            Common.SetActive(disableMark, false);
            //Common.SetActive(addIcon, true);
        }
        else
        {
            Common.SetActive(disableMark, true);
            Common.SetActive(addIcon, false);
            Common.SetActive(cupboard.gameObject, false);
        }
    }

    public void SetEqumentEnable(bool b)
    {
        Common.SetActive(cupboard.gameObject, b);
    }

    public void SetAddIconEnable(bool v)
    {
        Common.SetActive(addIcon, v);
    }
    void LoadRP()
    {
        if (null == rp)
            rp = Common.GetComponent<RoomPet>(rollPosition.gameObject);
    }
    int petId = -1;
    public void LoadPet(int petid)
    {
        LoadRP();
        petId = petid;
        if (petId==-1)
        {
            rp.ReleaseModel();
        }
        if (null == NetData.myPetList)
        {
            return;
        }
        foreach (var pet in NetData.myPetList.getPets())
        {
            if (pet.getPetId() == petId)
            {
                int cid = pet.getCid();
                CharacterTable roleTable;
                if (Tables.characterTable.TryGetValue(cid, out roleTable))
                {
                    rp.UpdatePet(petId, cid);
                    if(null != rp.model)
                         rp.model.CrossFade("Idle_Wep");
                }
            }
        }
    }

    public Vector3 GetRolePosition()
    {
        if (null == rollPosition)
            return Vector3.one;
        LoadRP();
        if (null != rp)
        {
            return rp.GetPosition();
        }
        return Vector3.one;
    }


    void ChangeWalk()
    {
        action = RoleActionType.WALK;
        float t = UnityEngine.Random.Range(0f, 1f);
        standPosition = Vector3.Lerp(rolePosition0, rolePosition1, t);
        rp.model.CrossFade("Walk");
    }
    void ChangeStand()
    {
        action = RoleActionType.STAND;
        
        actionTime = UnityEngine.Random.Range(3f, 5f);
        rp.model.CrossFade("Idle");
    }
    private void Update()
    {
        if (petId == -1)
            return;
        if (action == RoleActionType.STAND)
        {
            actionTime -= Time.deltaTime;
            rp.LookAt(Vector3.back);
            if (actionTime < 0f)
            {
                ChangeWalk();
               
            }
        }
        else
        {
            Vector3 pos = rp.GetPosition();
            pos = Vector3.MoveTowards(pos,standPosition,Time.deltaTime*walkSpeed);
            rp.SetPosition(pos);
            Vector3 dir = standPosition - pos;
            if (dir.magnitude < 0.001f)
            {
                ChangeStand();
            }
            else
            {
                rp.LookAt(dir);
            }
        }
    }

    public void ReleaseEnquipment(int j)
    {
        if (null == eqs)
        {
            return;
        }
        eqs[j].ReleaseModel( );
    }

    public void LoadEquipment(int index,string model)
    {
        if (null == eqs)
        {
            eqs = new GameObjectEX[3];
            for (int i = 0; i < eqs.Length; i++)
            {
                eqs[i] = GameObjectEX.Create();
                eqs[i].SetParentAndIdentyify(points[i]);
                eqs[i].gameObject.layer = 9;
            }
        }

        eqs[index].LoadModel(model);
        //points
    }

    public void Stand()
    {
        if (action == RoleActionType.WALK)
        {
            ChangeStand();
        }
        else
        {
            actionTime = 1f;
        }
    }


#endif
}
