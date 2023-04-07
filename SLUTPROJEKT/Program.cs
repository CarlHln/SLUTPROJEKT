using Raylib_cs;

const int field_width = 500;
const int field_height = 500;

Raylib.InitWindow(field_width,field_height,"slutprojekt");
Raylib.SetTargetFPS(60); 
Texture2D maincharacter = Raylib.LoadTexture("maincharacterimage.png");
Rectangle player = new Rectangle(225,225,10,10);

float speed = 2; 

string currentscene = "startscreen";

//create an empty list to store gameobjects 
List<Rectangle> gameObjects = new List<Rectangle>();

void CheckPlayerBoundaries(){
    if(player.x > field_width){
        player.x = 0;
    }

    else if(player.x < 0){
        player.x = field_width;
    }

    if(player.y > field_height){
        player.y = 0;
    }

    else if(player.y < 0){
        player.y = field_height;
    }
}

Raylib.ClearBackground(Color.WHITE);

while (Raylib.WindowShouldClose() == false){


if(currentscene == "gameplay"){
if(Raylib.IsKeyDown(KeyboardKey.KEY_A)){
    player.x -= speed;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_D)){
    player.x += speed;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_S)){
    player.y += speed;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_W)){
    player.y -= speed;
}

CheckPlayerBoundaries();

if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)){
    Rectangle newObject = new Rectangle(player.x, player.y, 5, 5);
    gameObjects.Add(newObject);
}

foreach(Rectangle gameObject in gameObjects){
    Raylib.DrawRectangleRec(gameObject, Color.BLUE);
}

}

//grafik
Raylib.BeginDrawing();

Raylib.DrawRectangleRec(player,Color.BLUE);
Raylib.DrawTexture(maincharacter,(int)player.x,(int)player.y,Color.BLACK);

if(currentscene == "startscreen"){
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawText("BLUE PEPPER SCRIBBLE",60,125,30,Color.BLACK);
    Raylib.DrawText("PRESS ENTER TO START",125,200,20,Color.BLUE);
    if(Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)){
        currentscene = "gameplay";
    }
}

else if (currentscene == "gameplay"){
    Raylib.ClearBackground(Color.WHITE);
    Raylib.DrawText($"Speed {speed}",10,405,20,Color.BLACK);
    Raylib.DrawText("UP or DOWN arrow to change speed",10,425,20,Color.BLACK);
    Raylib.DrawText("Hold space to draw",10,455,20,Color.BLACK);
    Raylib.DrawText("Press f to finish drawing",10,475,20,Color.BLACK);
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_UP)){
        speed ++;
    }
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)){
        speed --;
    }
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_F)){
        currentscene = "finished";
    }
}

else if(currentscene == "finished"){
    Raylib.DrawText("NICE ART!",20,30,40,Color.BLACK);
    Raylib.DrawText("Press backspace to return to menu",20,70,20,Color.BLACK);
    if(Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE)){
        currentscene = "startscreen";
        gameObjects.Clear();
        speed = 2;
    }
}

Raylib.EndDrawing();
}