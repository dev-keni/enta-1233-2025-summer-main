using MyCharacterInput;
using UnityEngine;
using System.Collections;
namespace MyCharacterInput
{
    public class AiPlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject AgentCharacter;
        [SerializeField] private GameObject MedkitPrefab;
        [SerializeField] private int MaxHealth;
        private int Health;

        private Vector3 medOffset = new Vector3 (0,0.5f,0);

        public Color dmgColor = Color.red;
        public float dmgColorDuration = 0.2f;

        private MeshRenderer meshRenderer;
        private Color ogColor;
        protected bool isDmgd = false;

        void Start()
        {
            Health = MaxHealth;
            meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                ogColor = meshRenderer.material.color;
            }
        }

        public void OnDMG(int Damage)
        {
            Health -= Damage;
            StartCoroutine(DamageFlash());
            if (Health <= 0)
            {
                Die();
            }
        }

        IEnumerator DamageFlash()
        {
            isDmgd = true;
            if (meshRenderer != null)
            {
                meshRenderer.material.color = dmgColor;
            }
            yield return new WaitForSeconds(dmgColorDuration);
            if (meshRenderer != null)
            {
                meshRenderer.material.color = ogColor;
            }
            isDmgd = false;
        }

        private void Die()
        {
            Instantiate(MedkitPrefab, AgentCharacter.transform.position-medOffset, AgentCharacter.transform.rotation);
            Destroy(gameObject);
        }
    }
}
