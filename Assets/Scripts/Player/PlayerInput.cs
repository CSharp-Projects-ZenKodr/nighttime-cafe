// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

namespace Player
{
    public class PlayerInput : IInputActionCollection, IDisposable
    {
        // Player
        private readonly InputActionMap m_Player;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Look;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_SprintOff;
        private readonly InputAction m_Player_SprintOn;
        private int m_GamepadSchemeIndex = -1;
        private int m_MouseKeyboardSchemeIndex = -1;
        private IPlayerActions m_PlayerActionsCallbackInterface;

        public PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9186556c-703a-4b2d-9040-8e5b045258da"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""46795371-2459-45c7-aadd-e375e38032e2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a1346bf4-a9ee-4916-95e8-fc0e669973c2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2eb57edd-3ff9-4e2d-8e5a-37aecfc2dae5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SprintOn"",
                    ""type"": ""Button"",
                    ""id"": ""a7d822d5-4f04-4295-804b-ac45e16fbf1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SprintOff"",
                    ""type"": ""Button"",
                    ""id"": ""6586e218-f71f-4ceb-b7b5-e7c548eabd47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASDKeys"",
                    ""id"": ""caf479fd-0fda-4cdf-b8f7-2e4dcf74a6b8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6d9cf0d8-03b8-4592-8378-64e9d93d4d5e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""cb20d93c-b724-46c8-ab50-62bc04bbaa2a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c9991bc4-48c4-48f2-a855-c72236d8b5c7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0089e595-a347-4ead-be96-fdad9c5640f0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""0a08ab08-346e-40b2-b9d6-df341da1a42b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6ceff003-af06-42da-8045-1b657d776a3e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f726721c-02e0-478d-8300-b96ae3ead51d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""38b259be-466f-4296-92d2-61981dd149ea"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ff552dc5-86af-446c-a845-37466eb282b9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fa59e830-d638-4b95-91db-31ec66692b23"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2371029-4a14-48b5-8470-425c51eb198f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66c71f7b-b5f6-44e0-b0b3-ba4598d7233f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9173c99-d43d-48df-8923-5eb7a5762a4c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5cde700-4551-4a31-a070-68e926114da8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b86cba73-667f-4845-aaab-38f10f9633c0"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SprintOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aaa692b8-ae78-4dcf-ad60-3f6ba3c0c19f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""SprintOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cf5c45c-81f6-467c-9640-f531eb8190f6"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SprintOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""acd2a57d-34e2-448a-9ef0-413c37fa50ea"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""SprintOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse & Keyboard"",
            ""bindingGroup"": ""Mouse & Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", true);
            m_Player_Move = m_Player.FindAction("Move", true);
            m_Player_Look = m_Player.FindAction("Look", true);
            m_Player_Jump = m_Player.FindAction("Jump", true);
            m_Player_SprintOn = m_Player.FindAction("SprintOn", true);
            m_Player_SprintOff = m_Player.FindAction("SprintOff", true);
        }

        private InputActionAsset asset { get; }
        public PlayerActions Player => new PlayerActions(this);

        public InputControlScheme MouseKeyboardScheme
        {
            get
            {
                if (m_MouseKeyboardSchemeIndex == -1)
                    m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse & Keyboard");
                return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
            }
        }

        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }

        public void Dispose()
        {
            Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public readonly struct PlayerActions
        {
            private readonly PlayerInput m_Wrapper;

            public PlayerActions(PlayerInput wrapper)
            {
                m_Wrapper = wrapper;
            }

            public InputAction Move => m_Wrapper.m_Player_Move;
            public InputAction Look => m_Wrapper.m_Player_Look;
            public InputAction Jump => m_Wrapper.m_Player_Jump;
            public InputAction SprintOn => m_Wrapper.m_Player_SprintOn;
            public InputAction SprintOff => m_Wrapper.m_Player_SprintOff;

            public InputActionMap Get()
            {
                return m_Wrapper.m_Player;
            }

            public void Enable()
            {
                Get().Enable();
            }

            public void Disable()
            {
                Get().Disable();
            }

            public bool enabled => Get().enabled;

            public static implicit operator InputActionMap(PlayerActions set)
            {
                return set.Get();
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    SprintOn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintOn;
                    SprintOn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintOn;
                    SprintOn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintOn;
                    SprintOff.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintOff;
                    SprintOff.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintOff;
                    SprintOff.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprintOff;
                }

                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance == null) return;
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Look.started += instance.OnLook;
                Look.performed += instance.OnLook;
                Look.canceled += instance.OnLook;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                SprintOn.started += instance.OnSprintOn;
                SprintOn.performed += instance.OnSprintOn;
                SprintOn.canceled += instance.OnSprintOn;
                SprintOff.started += instance.OnSprintOff;
                SprintOff.performed += instance.OnSprintOff;
                SprintOff.canceled += instance.OnSprintOff;
            }
        }

        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnSprintOn(InputAction.CallbackContext context);
            void OnSprintOff(InputAction.CallbackContext context);
        }
    }
}