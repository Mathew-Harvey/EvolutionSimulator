public void Move (float FB, float LR)
{
    //clamp the values of LR and FB
    LR = Mathf.Clamp (LR, -1, 1);
    FB = Mathf.Clamp (FB, 0, 1);

    // move the agent
    if (!creature.isDead)
    {
        //rotate around y - axis
        transform.Rotate(0, LR * rotateSpeed, 0);

        //move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        controller.SimpleMove(forward * speed * FB * -1);
    }
}