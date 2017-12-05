using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
    enum ITEM_TYPE {
                    BLANK,//空
                    CUBE,//キューブ
                    APPLE,//リンゴ
                    BOMB,//爆弾
                    COUNT,//総数
                    };

    int[] arrayld = { 5, 4, 3, 2, 1 };

    int[,] array = { {0,1},{0,2},{0,3}, {0,4},{0,5}} ;

    int[,] data = { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1 },
                    { 1, 0, 0, 0, 0, 2, 3, 0, 0, 0, 0,1 },
                    { 0, 0, 0, 0, 0, 2, 3, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 2, 3, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
                    { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0,0 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1 },
    };
    public GameObject cubePrefab;
    public GameObject applePrefab;
    public GameObject bombPrefab;
    void Start() {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                GameObject prefab = null;
                switch (data[i, j])
                {
                    case (int)ITEM_TYPE.CUBE:
                        prefab = cubePrefab;
                        break;
                    case (int)ITEM_TYPE.APPLE:
                        prefab = applePrefab;
                        break;
                    case (int)ITEM_TYPE.BOMB:
                        prefab = bombPrefab;
                        break;
                    default:
                        break;
                }
                if (prefab){
            Instantiate(prefab, new Vector3(j, -i, 0), Quaternion.identity);
        }
    }
        }
    }    

    // Update is called once per frame
    void Update () {
	
	}
}
