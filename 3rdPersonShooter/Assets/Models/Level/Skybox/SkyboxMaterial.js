#pragma strict
import LitJson;

var url:String;
var basehostname:String;
var key:String;
var randomnumber:int;
var tumblobj:JsonData;
var photoURL:JsonData;
var www:WWW;
var photo:WWW;
var response:JsonData;

function Start(){
key="2UThQKPHvAow1FP4LP11BogDEWI8Ni8bdjbF7nO5ggUHOW0sOx";
basehostname="fuckyeahtheuniverse.tumblr.com";
url= "http://api.tumblr.com/v2/blog/"+basehostname+"/posts/photo?api_key="+key;
randomnumber=Mathf.RoundToInt(Mathf.Floor(Random.value*10.0));
www = new WWW( url );
yield www;
tumblobj=JsonMapper.ToObject(www.text);
photoURL=tumblobj["response"]["posts"][randomnumber]["photos"][0]["original_size"]["url"];
photo= new WWW(photoURL+'');
yield photo;
var tex = new Texture2D (4, 4);
tex.LoadImage(photo.bytes);
//photo.LoadImageIntoTexture(RenderSettings.skybox.mainTexture);
RenderSettings.skybox.mainTexture=tex;
RenderSettings.skybox.SetTexture("_FrontTex", tex);
RenderSettings.skybox.SetTexture("_BackTex", tex);
RenderSettings.skybox.SetTexture("_LeftTex", tex);
RenderSettings.skybox.SetTexture("_RightTex", tex);
RenderSettings.skybox.SetTexture("_UpTex", tex);
RenderSettings.skybox.SetTexture("_DownTex", tex);
RenderSettings.skybox.color=UnityEngine.Color.grey;
var cheese="mozzarella";
//photoURL=tumblobj[0].response.posts[randomnumber].photos[0].original_size.url;
//photo= new WWW(photoURL);
//yield photo;
//RenderSettings.skybox.mainTexture=photo.texture;
}

function Update() {
randomnumber=Mathf.RoundToInt(Mathf.Floor(Random.value*25));
//photo= new WWW(photoURL);
//yield photo;
//RenderSettings.skybox.mainTexture=photo.texture;
}
