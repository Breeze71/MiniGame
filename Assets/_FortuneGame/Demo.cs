using UnityEngine ;
using EasyUI.PickerWheelUI ;
using UnityEngine.UI ;
using TMPro;
using DG.Tweening;

public class Demo : MonoBehaviour {
   [SerializeField] private Button uiSpinButton ;
   [SerializeField] private Text uiSpinButtonText ;

   [SerializeField] private PickerWheel pickerWheel ;
   [SerializeField] private Text fortuneItemTEXT;

   private RectTransform fortuneItem;


   private void Awake() 
   {
      fortuneItem = fortuneItemTEXT.GetComponent<RectTransform>();

      fortuneItem.DOScale(0f, .1f);
   }
   private void Start () {
      uiSpinButton.onClick.AddListener (() => {

         uiSpinButton.interactable = false ;
         uiSpinButtonText.text = "Spinning" ;

         pickerWheel.OnSpinStart(() =>
         {
            fortuneItemTEXT.GetComponent<RectTransform>().DOScale(0f, .1f);
         });

         pickerWheel.OnSpinEnd (wheelPiece => {
            Debug.Log (
               @" <b>Index:</b> " + wheelPiece.Index + "           <b>Label:</b> " + wheelPiece.Label
               + "\n <b>Amount:</b> " + wheelPiece.Amount + "      <b>Chance:</b> " + wheelPiece.Chance + "%"
            ) ;

            fortuneItem.DOScale(1f, .25f).SetEase(Ease.InOutSine);
            
            fortuneItemTEXT.text = wheelPiece.Label;

            uiSpinButton.interactable = true ;
            uiSpinButtonText.text = "Spin" ;
         }) ;

         pickerWheel.Spin () ;

      }) ;

   }

}
