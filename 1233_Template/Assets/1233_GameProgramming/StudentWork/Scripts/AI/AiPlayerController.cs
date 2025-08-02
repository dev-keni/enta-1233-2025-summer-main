using MyCharacterInput;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
namespace MyCharacterInput
{
    public class AiPlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject AgentCharacter;
        [SerializeField] private GameObject MedkitPrefab;
        [FormerlySerializedAs("MaxHealth")][SerializeField] private int _maxHealth;
        [SerializeField] private EnemyManager _enemyManager;
        private int Health;

        private Vector3 medOffset = new Vector3 (0,0.5f,0);

        public Color dmgColor = Color.red;
        public float dmgColorDuration = 0.2f;

        private MeshRenderer meshRenderer;
        private Color ogColor;
        protected bool isDmgd = false;

        private bool _dead = false;

        void Start()
        {
            Health = _maxHealth;
            meshRenderer = GetComponent<MeshRenderer>();
            GameObject foundObject = GameObject.Find("EnemyManager");
            _enemyManager = foundObject.GetComponent<EnemyManager>();
            if (meshRenderer != null)
            {
                ogColor = meshRenderer.material.color;
            }
        }

        public void OnDMG(int Damage)
        {
            if (_dead) return;
            Health -= Damage;
            StartCoroutine(DamageFlash());
            if (Health <= 0)
            {
                _dead = true;
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
            _enemyManager.OnDeath();
            Instantiate(MedkitPrefab, AgentCharacter.transform.position-medOffset, AgentCharacter.transform.rotation);
            StartCoroutine(DestroyGameObject());
        }
        IEnumerator DestroyGameObject()
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(transform.parent.gameObject);
        }
    }
}
