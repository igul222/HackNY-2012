var target:Transform;
var bulletPrefab:Transform;
function Update () {
	transform.LookAt(target);
	if (Input.GetButtonDown("Jump")) {
		var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		bullet.rigidbody.AddForce(transform.forward * 3000);
	}
}