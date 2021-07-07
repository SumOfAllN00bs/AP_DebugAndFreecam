using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NewtonVR
{
	public class NVRHead : MonoBehaviour
	{
		public NVRHead()
		{
			this.windowRect = new Rect(20f, 20f, (float)(Screen.width - 40), (float)(Screen.height - 40));
			this.titleBarRect = new Rect(0f, 0f, 10000f, 20f);
			this.clearLabel = new GUIContent("Clear", "Clear the contents of the console.");
			this.collapseLabel = new GUIContent("Collapse", "Hide repeated messages.");
			this.debugLogs = new List<NVRHead.LogLine>();
			this.handLight = false;
		}

		public virtual void Initialize()
		{
		}

		private void Update()
		{
			NVRInputDevice nvrinputDevice = (NVRInputDevice)UnityEngine.Object.FindObjectOfType(typeof(NVRInputDevice));
			PlayerController playerController = (PlayerController)UnityEngine.Object.FindObjectOfType(typeof(PlayerController));
			Vector2 axis2D = nvrinputDevice.GetAxis2D(NVRButtons.Axis2);
			if (Input.GetKeyDown(KeyCode.H))
			{
				foreach (GameObject gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
				{
					if (gameObject.layer == 8)
					{
						gameObject.layer = 0;
					}
				}
			}
			if (Input.GetKeyDown(KeyCode.BackQuote))
			{
				this.debugVisible = !this.debugVisible;
			}
			if (Input.GetKeyDown(KeyCode.F1))
			{
				this.inputMethod++;
				if (this.inputMethod == 9)
				{
					this.inputMethod = 0;
				}
				Debug.Log("using input method: " + this.inputMethod);
			}
			if (Input.GetKeyDown(KeyCode.F2))
			{
				this.freecamEnabled = !this.freecamEnabled;
			}
			if (this.freecamEnabled)
			{
				if (Input.GetKeyDown(KeyCode.F4))
				{
					this.speed = ((this.speed > 10f) ? 0f : (this.speed + 1f));
					Debug.Log("freecam speed: " + this.speed);
				}
				switch (this.inputMethod)
				{
				case 0:
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y > 0.5)
					{
						playerController.CachedTransform.Translate(0f, this.speed * Time.deltaTime, 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y < -0.5)
					{
						playerController.CachedTransform.Translate(0f, -(this.speed * Time.deltaTime), 0f, Space.World);
					}
					if ((double)axis2D.x < -0.3)
					{
						playerController.CachedTransform.Rotate(Vector3.up, -(this.speed * 30f * Time.deltaTime * Math.Abs(axis2D.x)));
					}
					if ((double)axis2D.x > 0.6)
					{
						playerController.CachedTransform.Rotate(Vector3.up, this.speed * 30f * Time.deltaTime * Math.Abs(axis2D.x));
					}
					if ((double)axis2D.y < -0.6)
					{
						playerController.CachedTransform.Translate(0f, 0f, -(this.speed * Time.deltaTime * Math.Abs(axis2D.y)), Space.Self);
					}
					if ((double)axis2D.y > 0.3)
					{
						playerController.CachedTransform.Translate(0f, 0f, this.speed * Time.deltaTime * axis2D.y, Space.Self);
					}
					break;
				case 1:
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y > 0.5)
					{
						playerController.CachedTransform.Translate(0f, this.speed * Time.deltaTime, 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y < -0.5)
					{
						playerController.CachedTransform.Translate(0f, -(this.speed * Time.deltaTime), 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis0).x < -0.3)
					{
						playerController.CachedTransform.Rotate(Vector3.up, -(this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis0).x)));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis0).x > 0.6)
					{
						playerController.CachedTransform.Rotate(Vector3.up, this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis0).x));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis0).y < -0.6)
					{
						playerController.CachedTransform.Translate(0f, 0f, -(this.speed * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis0).y)), Space.Self);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis0).y > 0.3)
					{
						playerController.CachedTransform.Translate(0f, 0f, this.speed * Time.deltaTime * nvrinputDevice.GetAxis2D(NVRButtons.Axis0).y, Space.Self);
					}
					break;
				case 2:
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y > 0.5)
					{
						playerController.CachedTransform.Translate(0f, this.speed * Time.deltaTime, 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y < -0.5)
					{
						playerController.CachedTransform.Translate(0f, -(this.speed * Time.deltaTime), 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis1).x < -0.3)
					{
						playerController.CachedTransform.Rotate(Vector3.up, -(this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis1).x)));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis1).x > 0.6)
					{
						playerController.CachedTransform.Rotate(Vector3.up, this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis1).x));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis1).y < -0.6)
					{
						playerController.CachedTransform.Translate(0f, 0f, -(this.speed * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis1).y)), Space.Self);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis1).y > 0.3)
					{
						playerController.CachedTransform.Translate(0f, 0f, this.speed * Time.deltaTime * nvrinputDevice.GetAxis2D(NVRButtons.Axis1).y, Space.Self);
					}
					break;
				case 3:
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y > 0.5)
					{
						playerController.CachedTransform.Translate(0f, this.speed * Time.deltaTime, 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y < -0.5)
					{
						playerController.CachedTransform.Translate(0f, -(this.speed * Time.deltaTime), 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis2).x < -0.3)
					{
						playerController.CachedTransform.Rotate(Vector3.up, -(this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis2).x)));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis2).x > 0.6)
					{
						playerController.CachedTransform.Rotate(Vector3.up, this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis2).x));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis2).y < -0.6)
					{
						playerController.CachedTransform.Translate(0f, 0f, -(this.speed * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis2).y)), Space.Self);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis2).y > 0.3)
					{
						playerController.CachedTransform.Translate(0f, 0f, this.speed * Time.deltaTime * nvrinputDevice.GetAxis2D(NVRButtons.Axis2).y, Space.Self);
					}
					break;
				case 4:
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y > 0.5)
					{
						playerController.CachedTransform.Translate(0f, this.speed * Time.deltaTime, 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y < -0.5)
					{
						playerController.CachedTransform.Translate(0f, -(this.speed * Time.deltaTime), 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis3).x < -0.3)
					{
						playerController.CachedTransform.Rotate(Vector3.up, -(this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis3).x)));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis3).x > 0.6)
					{
						playerController.CachedTransform.Rotate(Vector3.up, this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis3).x));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis3).y < -0.6)
					{
						playerController.CachedTransform.Translate(0f, 0f, -(this.speed * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis3).y)), Space.Self);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis3).y > 0.3)
					{
						playerController.CachedTransform.Translate(0f, 0f, this.speed * Time.deltaTime * nvrinputDevice.GetAxis2D(NVRButtons.Axis3).y, Space.Self);
					}
					break;
				case 5:
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y > 0.5)
					{
						playerController.CachedTransform.Translate(0f, this.speed * Time.deltaTime, 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y < -0.5)
					{
						playerController.CachedTransform.Translate(0f, -(this.speed * Time.deltaTime), 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis4).x < -0.3)
					{
						playerController.CachedTransform.Rotate(Vector3.up, -(this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis4).x)));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis4).x > 0.6)
					{
						playerController.CachedTransform.Rotate(Vector3.up, this.speed * 30f * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis4).x));
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis4).y < -0.6)
					{
						playerController.CachedTransform.Translate(0f, 0f, -(this.speed * Time.deltaTime * Math.Abs(nvrinputDevice.GetAxis2D(NVRButtons.Axis4).y)), Space.Self);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Axis4).y > 0.3)
					{
						playerController.CachedTransform.Translate(0f, 0f, this.speed * Time.deltaTime * nvrinputDevice.GetAxis2D(NVRButtons.Axis4).y, Space.Self);
					}
					break;
				case 6:
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y > 0.5)
					{
						playerController.CachedTransform.Translate(0f, this.speed * Time.deltaTime, 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y < -0.5)
					{
						playerController.CachedTransform.Translate(0f, -(this.speed * Time.deltaTime), 0f, Space.World);
					}
					if (nvrinputDevice.GetPress(NVRButtons.DPad_Left))
					{
						playerController.CachedTransform.Rotate(Vector3.up, -(this.speed * 30f * Time.deltaTime));
					}
					if (nvrinputDevice.GetPress(NVRButtons.DPad_Right))
					{
						playerController.CachedTransform.Rotate(Vector3.up, this.speed * 30f * Time.deltaTime);
					}
					if (nvrinputDevice.GetPress(NVRButtons.DPad_Down))
					{
						playerController.CachedTransform.Translate(0f, 0f, -(this.speed * Time.deltaTime), Space.Self);
					}
					if (nvrinputDevice.GetPress(NVRButtons.DPad_Up))
					{
						playerController.CachedTransform.Translate(0f, 0f, this.speed * Time.deltaTime, Space.Self);
					}
					break;
				case 7:
					if (nvrinputDevice.GetPress(NVRButtons.A))
					{
						playerController.CachedTransform.Translate(0f, this.speed * Time.deltaTime, 0f, Space.World);
					}
					if (nvrinputDevice.GetPress(NVRButtons.B))
					{
						playerController.CachedTransform.Translate(0f, -(this.speed * Time.deltaTime), 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y > 0.5)
					{
						playerController.CachedTransform.Translate(0f, 0f, this.speed * Time.deltaTime, Space.Self);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y < -0.5)
					{
						playerController.CachedTransform.Translate(0f, 0f, -(this.speed * Time.deltaTime), Space.Self);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).x > 0.5)
					{
						playerController.CachedTransform.Translate(this.speed * Time.deltaTime, 0f, 0f, Space.Self);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).x < -0.5)
					{
						playerController.CachedTransform.Translate(-(this.speed * Time.deltaTime), 0f, 0f, Space.Self);
					}
					break;
				case 8:
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y > 0.5)
					{
						playerController.CachedTransform.Translate(0f, this.speed * Time.deltaTime, 0f, Space.World);
					}
					if ((double)nvrinputDevice.GetAxis2D(NVRButtons.Touchpad).y < -0.5)
					{
						playerController.CachedTransform.Translate(0f, -(this.speed * Time.deltaTime), 0f, Space.World);
					}
					if (nvrinputDevice.GetPress(NVRButtons.A))
					{
						playerController.CachedTransform.Rotate(Vector3.up, -(this.speed * 30f * Time.deltaTime));
					}
					if (nvrinputDevice.GetPress(NVRButtons.B))
					{
						playerController.CachedTransform.Rotate(Vector3.up, this.speed * 30f * Time.deltaTime);
					}
					if (nvrinputDevice.GetPress(NVRButtons.X))
					{
						playerController.CachedTransform.Translate(0f, 0f, -(this.speed * Time.deltaTime), Space.Self);
					}
					if (nvrinputDevice.GetPress(NVRButtons.Y))
					{
						playerController.CachedTransform.Translate(0f, 0f, this.speed * Time.deltaTime, Space.Self);
					}
					break;
				}
			}
			if (Input.GetKeyDown(KeyCode.F5))
			{
				int num = 0;
				foreach (MeshRenderer meshRenderer in UnityEngine.Object.FindObjectsOfType<MeshRenderer>())
				{
					if (meshRenderer.material != null && meshRenderer.material.name != null && meshRenderer.material.name.Contains("trigger"))
					{
						num++;
					}
				}
				Debug.Log("Trigger meshes found: " + num);
			}
			if (Input.GetKeyDown(KeyCode.F6))
			{
				GameObject[] array = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(true);
				}
			}
			if (Input.GetKeyDown(KeyCode.F8))
			{
				GameObject rh = GameObject.Find("RightHand");
				if (rh != null && !this.handLight)
				{
					rh.AddComponent<Light>();
					this.handLight = true;
				}
				else if (rh != null && this.handLight)
				{
					UnityEngine.Object.Destroy(rh.GetComponent<Light>());
					this.handLight = false;
				}
			}
			int num2 = 0;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				num2 = 8;
			}
			if (Input.GetKeyDown(KeyCode.Keypad1))
			{
				StationController stationController = UnityEngine.Object.FindObjectOfType<StationController>();
				if (stationController != null)
				{
					stationController.ChangeAlternativeLevel("AccPlus_Stomach_MASTER");
					stationController.BroadcastLevelComplete();
				}
				return;
			}
			if (Input.GetKeyDown(KeyCode.Keypad2))
			{
				StationController stationController2 = UnityEngine.Object.FindObjectOfType<StationController>();
				if (stationController2 != null)
				{
					stationController2.ChangeAlternativeLevel("AccPlus_Finale_MASTER");
					stationController2.BroadcastLevelComplete();
				}
				return;
			}
			if (Input.GetKeyDown(KeyCode.Keypad3))
			{
				StationController stationController3 = UnityEngine.Object.FindObjectOfType<StationController>();
				if (stationController3 != null)
				{
					stationController3.ChangeAlternativeLevel("AccPlus_Arg_MASTER");
					stationController3.BroadcastLevelComplete();
				}
				return;
			}
			if (Input.GetKeyDown(KeyCode.Keypad4))
			{
				StationController stationController4 = UnityEngine.Object.FindObjectOfType<StationController>();
				if (stationController4 != null)
				{
					stationController4.ChangeAlternativeLevel("AccPlus_Office_MASTER");
					stationController4.BroadcastLevelComplete();
				}
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				SceneManager.LoadScene(num2, LoadSceneMode.Additive);
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				SceneManager.LoadScene(1 + num2, LoadSceneMode.Additive);
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3))
			{
				SceneManager.LoadScene(2 + num2, LoadSceneMode.Additive);
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha4))
			{
				SceneManager.LoadScene(3 + num2, LoadSceneMode.Additive);
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha5))
			{
				SceneManager.LoadScene(4 + num2, LoadSceneMode.Additive);
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha6))
			{
				SceneManager.LoadScene(5 + num2, LoadSceneMode.Additive);
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha7))
			{
				SceneManager.LoadScene(6 + num2, LoadSceneMode.Additive);
				return;
			}
			if (Input.GetKeyDown(KeyCode.Alpha8))
			{
				SceneManager.LoadScene(7 + num2, LoadSceneMode.Additive);
			}
		}

		private void OnEnable()
		{
			Application.logMessageReceived += this.HandleLog;
		}

		private void OnDisable()
		{
			Application.logMessageReceived -= this.HandleLog;
		}

		private void OnGUI()
		{
			if (this.debugVisible)
			{
				this.windowRect = GUILayout.Window(900, this.windowRect, new GUI.WindowFunction(this.debugWindow), "Debug", new GUILayoutOption[0]);
			}
		}

		private void debugWindow(int debugID)
		{
			this.scrollP = GUILayout.BeginScrollView(this.scrollP, new GUILayoutOption[0]);
			for (int i = 0; i < this.debugLogs.Count; i++)
			{
				NVRHead.LogLine logLine = this.debugLogs[i];
				if (!this.collapse || i <= 0 || !(logLine.message == this.debugLogs[i - 1].message))
				{
					GUI.contentColor = NVRHead.logTypeColors[logLine.type];
					GUILayout.Label(logLine.message, new GUILayoutOption[0]);
				}
			}
			if (this.newDebugMessage)
			{
				GUI.ScrollTo(new Rect(0f, this.windowRect.height, 1f, 1f));
				this.newDebugMessage = false;
			}
			GUILayout.EndScrollView();
			GUI.contentColor = Color.white;
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(this.clearLabel, new GUILayoutOption[0]))
			{
				this.debugLogs.Clear();
			}
			this.collapse = GUILayout.Toggle(this.collapse, this.collapseLabel, new GUILayoutOption[]
			{
				GUILayout.ExpandWidth(false)
			});
			GUILayout.EndHorizontal();
			GUI.DragWindow(this.titleBarRect);
		}

		private void HandleLog(string message, string stackTrace, LogType type)
		{
			this.debugLogs.Add(new NVRHead.LogLine
			{
				message = message,
				stackTrace = stackTrace,
				type = type
			});
			this.newDebugMessage = true;
		}

		private GameObject CreateText(Transform canvas_transform, float x, float y, string text_to_print, int font_size, Color text_color)
		{
			GameObject gameObject = new GameObject("Text2");
			gameObject.transform.SetParent(canvas_transform);
			gameObject.AddComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
			Text text = gameObject.AddComponent<Text>();
			text.text = text_to_print;
			text.fontSize = font_size;
			text.color = text_color;
			return gameObject;
		}

		private bool debugVisible;

		private Vector2 scrollP;

		private bool collapse;

		private const int margin = 10;

		private Rect windowRect;

		private Rect titleBarRect;

		private GUIContent clearLabel;

		private GUIContent collapseLabel;

		private List<NVRHead.LogLine> debugLogs;

		private static Dictionary<LogType, Color> logTypeColors = new Dictionary<LogType, Color>
		{
			{
				LogType.Assert,
				Color.white
			},
			{
				LogType.Error,
				Color.red
			},
			{
				LogType.Exception,
				Color.red
			},
			{
				LogType.Log,
				Color.white
			},
			{
				LogType.Warning,
				Color.yellow
			}
		};

		private float speed = 5f;
		private bool newDebugMessage;
		private bool verticalControl;
		private bool freecamEnabled;
		private int inputMethod;
		private bool handLight;
		private struct LogLine
		{
			public string message;
			public string stackTrace;
			public LogType type;
		}
	}
}
