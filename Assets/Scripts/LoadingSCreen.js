#pragma strict

function Awake ()
{
    LeaveScene ();
}
 
function LeaveScene ()
{
    yield WaitForSeconds (1);
    Application.LoadLevel(1);
}