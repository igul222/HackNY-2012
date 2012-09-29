var moveSpeed:float = 1.0;
var turnSpeed:float = 1.0;


function Update () 
{
	if(Input.GetButton("Forward")) {
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}
	if(Input.GetButton("Backward")) {
		transform.position -= transform.forward * moveSpeed * Time.deltaTime;
	}
	if(Input.GetButton("Left")) {
		transform.eulerAngles.y -= turnSpeed * Time.deltaTime;
	}
	if(Input.GetButton("Right")) {
		transform.eulerAngles.y += turnSpeed * Time.deltaTime;
	}
}