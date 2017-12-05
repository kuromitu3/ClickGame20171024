using UnityEngine;
using System.Collections;

public class Tetris : MonoBehaviour {
    enum PIECE_TYPE
    {
        I, T, O, S, Z, J, L,

    }
    enum ITEM_TYPE
    {
        BLANK,
        WALL,
        ACTIVE,
        AFTER,

    }
    public float speed = 1.0f;
    float autoDownTimer = 0.0f;
    public float moveSpeed = 0.1f;
    float moveTimer = 0.0f;
    const int STAGE_WIDTH = 12;
    const int STAGE_HEIGHT = 12;
    int[,] stageDate;
    const int BLOCK_COUNT = 4;
    int[] x1 = new int[BLOCK_COUNT];
    int[] y1 = new int[BLOCK_COUNT];
    int pieceX = 6, pieceY= 1 ;

    PIECE_TYPE pieceType = PIECE_TYPE. I;
    GameObject[,] viewBlocks;
    Color[] PieceColors = new Color[]
    {
        Color.cyan, //I.
        Color.magenta,//T.
        Color.yellow, //o.
        Color.green, //s.
        Color.red, //z.
        Color.blue,// j.
        new Color (1.0f,0.5f,0.0f), //L.
    };

    /// <summary>
    /// ステージ配列初期化
    /// </summary>
    voidStageData()
    {
        stageData = new int[STAGE_HEIGHT, STAGE_WIDTH];
        Debug.Log("ステージデータの初期化完了");
    }
    /// <summary>
    /// ステージの見た目初期化
    /// </summary>
    void InitStageObject()
    {
        viewBlocks = new GameObject[STAGE_HEIGHT, STAGE_WIDTH];
        int blockNumber = 0;
        for (int i = 0; i < STAGE_HEIGHT; i++)
        {
            for (int j = 0; j < STAGE_WIDTH; j++)
            {
                viewBlocks[i, j] =
                    GameObject.CreatePrimitive(PrimitiveType.Cube);
                viewBlocks[i, j].name = "Block" + blockNumber;
                blockNumber++;
                viewBlocks[i, j].trasform.poition = new Vector3(j, i * -1, 0);
            }
        }
        Debug.Log("ステージの見た目の初期化完了");
    }
/// <summary>
/// カメラ初期化
/// </summary>

    void InitCamera () {
        Camera.main.transform.position = new Vector3(
            (stageData.GetLength(1) - 1) / 2.0f,
             stageData.GetLength(0) - 1) / -2.0f,
             -STAGE_HEIGHT);
        Debug.Log("カメラの初期化完了");
    }
	/// <summary>
    /// 全てのピースを消去する
    /// </summary>
	void ClearStage()
    {
        for (int i = 0; i < STAGE_HEITGHT; i++)
        {
            for (int j = 0; j < STAGE_HEITGHT; j++)
            {
                if (j == 0 || j == STAGE_WIDTH - 1 || I == STAGE_HEIGE - 1)
                {
                    stageDate[i, j] = (int)ITEM_TYPE.WALL;
                }
                else
                {
                    stageDate[i, j] = (int)ITEM_TYPE.BLANK;
                }
            }
        } 
	}
    /// <summary>
    /// 落下中のブロックと落下中のブロックのあたり判定。
    /// </summary>
    /// <returns>あたったブロックの数</returns>
bool hitCheck()
    {
        bool hit = false;
        int cx, cy;
        for(int i = 0;i<BLOCK_COUNT; i++ ){
            cx = pieceX + x1[i];
            cy = pieceY + y1[i];
            //ブロックの位置がステージ内に収まっている？
            if (cx >=0 && cx < STAGE_WIDTH && cy >=0 && cy < STAGE_HEIGHT)
            {
           //空じゃない?
           if(voidStageData[cy,cx] !=(int)ITEM_TYPE.BLANK)
                {
                    hit = true;
                }
            }
        }
        return hit;
    }
///<summary>
///ブロックを二位元配列にコピー
/// </summary>>
/// <param name="a">The alpha component.</param>
void PutPiece(int item)
{
        int cx, cy;
        for(int i=0; i<BLOCK_COUNT;i++)
        {
            cx = pieceX + x1[i];
            cy = pieceY + y1[i];
            //ブロックの位置がステージ内に収まっている？
                if(cx >= 0 && cx < STAGE_WIDTH && cy >= 0 && cy < STAGE_HEIGHT)
            {
                StageData[cx,cy]=item;
            }
        }
///<summary>
///ピースの新規作成
///<summary>

        void StageData NewPiece(){
            //ピースの形状データ。
            int[,,] pieceData = new int[,,]
            {
                { {0,-1},{0,0},{0,1},{0,2} },//I.
                { {0,-1},{0,0},{0,1},{0,2} },//T.
                { {0,-1},{0,0},{0,1},{0,2} },//O.
                { {0,-1},{0,0},{0,1},{0,2} },//S.
                { {0,-1},{0,0},{0,1},{0,2} },//Z.
                { {0,-1},{0,0},{0,1},{0,2} },//J.
                { {0,-1},{0,0},{0,1},{0,2} },//L.
            };
            pieceX = 6;
            pieceY = 1;
            pieceType = (PIECE_TYPE)Random.Range(0, 7);//抽選
            for (int i=0; i< BLOCK_COUNT;i++)
            {
                x1[i] = pieceData[(int)pieceType, i, 0];
                y1[i] = pieceData[(int)pieceType, i, 1];
            }

            if (hitCheck())
            {
                Debug.Log("ゲームオーバ－");
                ClearStage();
            }
            PutPiece((int)ITEM_TYPE.ACTIVE);
        }
        ///<summary>
        ///ブロックを描画
        ///</summary>
        void DrawStage(){
            for (int i = 0; i < STAGE_HEIGHT;i++) {
                for (int j = 0; j < STAGE_HEIGHT; j++) {
                    MeshRenderer mr = ViewBlocks[i, j].GetComponent<MeshRenderer>();
                    Material m = viewBlocks[i,j]GetComponent<Renderer>().material;
                    mr.enabled = true;
                    switch (StageData[i, j]) {
                        case (int)ITEM_TYPE.BLANK:
                            mr.enabled = false;
                            break;
                        case (int)ITEM_TYPE.WALL:
                            m.color = Color.black;
                            break;
                        case (int)ITEM_TYPE.ACTIVE:
                            m.color = PieceColors[(int)pieceType];
                            break;
                        case (int)ITEM_TYPE.AFTER:
                            m.color = Color.gray;
                            break;
                        default:
                            break;
                    }

                }

            }

        }
        ///<summary>
        ///ピースを回転
        ///</summary>
        ///<param name="r">回転方向.</param>>
        void turnPiece(int r){
            int temp;
            //回転する位置が正常?
            if (r==1||r==-1) {
                for (int i = 0; i<BLOCK_COUNT;i++) {
                    temp = x1[i] * r;
                    x1[i] = -y1[i] * r;
                    y1[i] = temp;
                }
            }
        }
        ///<summary>
        ///入力によるピースの回転
        ///</summary>>
        void RotatePiece(){
            //回転方向.
            int r = 0;
            PutPiece((int)ITEM_TYPE.BLANK);
            if(Input.GetKeyDown(KeyCode.Z))
                {
                r = -1;
            }
            PutPiece((int)ITEM_TYPE.BLANK);
            if (Input.GetKeyDown(KeyCode.X))
            {
                r = 1;
            }
            if (r != 0) {
                turnPiece(-r);//回転取り消し
            }
        }
        PutPiece((int)ITEM_TYPE.ACTIVE);
        ///<summary>
        ///入力によるピースの移動
        ///</summary>>
        void MovePiece(){
            int oldx = pieceX;
            int oldy = pieceY;
            PutPiece((int)ITEM_TYPE.BLANK);
            {
                pieceX--;
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                pieceX++;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pieceY++;
            }
            //移動できない場合は移動を取り消す
            if (hitCheck()) {
                pieceX = oldx;
                pieceY = oldy;
            }
            PutPiece((int)ITEM_TYPE.ACTIVE);
        }
        ///<summary>
        ///ブロックを下に動かす
        ///</summary>>
        void EraseDown(int downCount){
            int currentLine = STAGE_HEIGHT - 2;
            bool checkCountinue = ture;
            while (checkCountinue)
            {
                bool empty = true;
                int x;
                //枠を除く横一列分回す
                for (x = 1; x < STAGE_WIDTH-1; x++)
                {
                    //空以外のブロックがある？
                    if (stageData[currentLine,x] !=(int)ITEM_TYPE.BLANK ){
                        empty = false;
                }
            }
            //全て空？ 
            if(empty)
                {
                    for (int y = currentLine; y >=1; y--)
                    {
                        for (x=1; x<STAGE_WIDTH - 1; x++)
                        {
                            stageData[y, x] = StageData[y - 1,

                        }
                    }
                    downCount--;
                    //下げる必要がもうない？
                    if(downCount == 0)
                    {
                        checkCountinue = false;
                    }
                }                            
            }
        }
        ///<summary>
        ///ラインがすべてそろっているかチェック
        ///</summary>
        void LineCheck(){
            int eraseLine = 0;
            for (int y =0; y<STAGE_HEIGHT - 1;y++>) {
                bool filled = true;
                int x;
                for(x=1;x<STAGE_WIDTH-1; x++){
                    //空？
                    if (stageData[y, x] == (int)ITEM_TYPE.BLANK)
                    {
                        filled = false;
                    }
                }
                //横一列全てにブロックがおかれている？
                if(filled)
                {
                    for (x=1;x<STAGE_WIDTH - 1;x++ ) {
                        stageData[y,x] = (int)ITEM_TYPE.BLANK;
                        eraseLine++;
                    }
                }
            }
            //消されたァ員が１つ以上ある？
            if (eraseLine>0) {
                EraseDown(eraseLine);
            }
        }
        ///<summary>
        ///ピースの自動落下.
        ///</summary>>
        void AutoDown()
            {
            PutPiece((int)ITEM_TYPE.BLANK);
            pieceY++;
            ///最下層まで移動したか調べる.
            if (hitCheck())
            {
                pieceY--;
                //ピースの位置を確定する
                PutPiece((int)ITEM_TYPE.AFTER);
                LineCheck();
                //新しいピース生成
                Debug.Log("新しいピース");
                NewPiece();
            }
            else
            {
                PutPiece((int)ITEM_TYPE.ACTIVE);
            }
        }
        //Use this for initialization
        void Start()
            {
            InitStageData();
            InitStageObject();
            InitCamera();
            ClearStage();
            NewPiece();
            DrawStage();
        }
        //Update iscalled once per frame
        void Update()
            {
            moveTimer += Time.deltaTime;
            autoDownTimer += Time.deltaTime;
            RotatePiece;
            if(moveTimer >= moveSpeed)
            {
                MovePiece();
                moveTimer = 0.0f;
            }
            if(autoDownTimer >= speed)
            {
                AutoDown();
                autoDownTimer = 0.0f;
            }
            DrawStage();
        }
    }




