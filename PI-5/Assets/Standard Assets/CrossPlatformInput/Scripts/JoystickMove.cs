/*
 * This script is from the Unity 5 Standard Assets with edits from Devin Curry
 * Search for changes tagged with the //DCURRY comment
 * Watch the tutorial here: www.Devination.com
 */
/*/edit by juan.amaral/*/
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class JoystickMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
        public static bool ClickMove = false;

        

        public int isPressed = 0;
        EventSystem evento;
        public PointerEventData data;

        public enum AxisOption
		{

			// Options for which axes to use
			Both, // Use both
			OnlyHorizontal, // Only horizontal
			OnlyVertical // Only vertical
		}

		public int MovementRange = 100;
		public AxisOption axesToUse = AxisOption.Both   ; // The options for the axes that the still will use
		public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
		public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input

		Vector3 m_StartPos;
		bool m_UseX; // Toggle for using the x axis
		bool m_UseY; // Toggle for using the Y axis
		CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
		CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input

		void Start() //DCURRY: Changed to Start from OnEnable
		{
			m_StartPos = transform.position;
			CreateVirtualAxes();
            data = new PointerEventData(evento);


        }
        void Update()
        {
            //for (int i = 0; i < Input.touchCount; ++i)
            //{
            //    if (Input.GetTouch(i).phase == TouchPhase.Began)
            //    {
            //        Debug.Log("atirando");
            //    }
            //}

            




                    IsPressed = 0;
            if (IsPressed == 1)
            {
                //Debug.Log("ta arrastando");
                //m_HorizontalVirtualAxis.Update(0);
                //m_VerticalVirtualAxis.Update(0);
            }
            if (IsPressed == 0)
            {
                //Debug.Log("Nao ta arrasando");
                //m_HorizontalVirtualAxis.Update(0);
                //m_VerticalVirtualAxis.Update(0);
            }
            //Debug.Log(IsPressed);
        }
          
		void UpdateVirtualAxes(Vector3 value)
		{
            if (IsPressed == 1)
            {
                //Debug.Log("ta arrastando");
                var delta = m_StartPos - value;
                delta.y = -delta.y;
                delta /= MovementRange;
                if (m_UseX)
                {
                    m_HorizontalVirtualAxis.Update(-delta.x);
                }

                if (m_UseY)
                {
                    m_VerticalVirtualAxis.Update(delta.y);
                }


                ClickMove = true;


            }
            //Debug.Log(AxisOption.Both);
            //Debug.Log(m_HorizontalVirtualAxis);
            //Debug.Log(m_VerticalVirtualAxis);
        }
        
		void CreateVirtualAxes()
		{
            
			// set axes to use
			m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
			m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

			// create new axes based on axes to use
			if (m_UseX)
			{
				m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
                

            }
			if (m_UseY)
			{
				m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
			}
		}


		public void OnDrag(PointerEventData data)
		{

			Vector3 newPos = Vector3.zero;
			if (m_UseX)
			{
				int delta = (int)(data.position.x - m_StartPos.x);
				//delta = Mathf.Clamp(delta, - MovementRange, MovementRange); //DCURRY: Dont want to clamp individual axis
				newPos.x = delta;
                //delta = deltaX;

            }

			if (m_UseY)
			{
				int delta = (int)(data.position.y - m_StartPos.y);
				//delta = Mathf.Clamp(delta, -MovementRange, MovementRange); //DCURRY: Dont want to clamp individual axis
				newPos.y = delta;
               // delta = deltaY;

            }
            //DCURRY: ClampMagnitude to clamp in a circle instead of a square
            transform.position = Vector3.ClampMagnitude(new Vector3(newPos.x, newPos.y, newPos.z), MovementRange) + m_StartPos;
            IsPressed = 1;
            UpdateVirtualAxes(transform.position);
            
        }

        public int IsPressed
        {
            get { return isPressed; }
            set { isPressed = value; }

        }

        public void OnPointerUp(PointerEventData data)
		{
			transform.position = m_StartPos;
			UpdateVirtualAxes(m_StartPos);
        }


		public void OnPointerDown(PointerEventData data) {
            
        }

		void OnDisable()
		{
            // remove the joysticks from the cross platform input
            if (m_UseX)
			{
				m_HorizontalVirtualAxis.Remove();
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis.Remove();
			}
		}
	}
}