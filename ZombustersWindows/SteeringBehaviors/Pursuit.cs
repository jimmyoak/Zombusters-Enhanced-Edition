using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ZombustersWindows
{
    public class Pursuit : Steering
    {
        public Vector2? Target;
        private Arrive _arrive;
        private SteeringEntity _evader;

        bool _evaderUpdated = false;

        /// <summary>
        /// Refresca
        /// </summary>
        /// <param name="evader"></param>
        public void UpdateEvaderEntity(SteeringEntity evader)
        {
            this._evader = evader;
            this._evaderUpdated = true;
        }

        /// <summary>
        /// Implementaci�n del c�lculo de steering par el comportamiento de tipo Seek
        /// </summary>
        /// <param name="entity">Datos b�sicos de la entidad</param>
        /// <returns></returns>
        internal override Vector2 CalculateSteering(SteeringEntity entity)
        {
            if (Target.HasValue)
            {
                if (_evaderUpdated)
                {
                    this._evaderUpdated = false;

                    Vector2 ToEvader = Target.Value - entity.Position;

                    float LookAheadTime = ToEvader.Length() /
                            (entity.MaxSpeed / 2 + this._evader.Speed);

                    _arrive.Target = this._evader.Position + this._evader.Velocity * LookAheadTime;

                    return _arrive.CalculateSteering(entity);
                }
                else
                    throw new Exception("Llamar primero al m�todo UpdateEvaderEntity");
            }
            else
            {
                throw new Exception("Debe indicarse el target para el steering de tipo Arrive");
            }
        }

        public Pursuit(Arrive.Deceleration deceleration, float decelerationBeginsAtDistance)
            : base(BehaviorType.pursuit)
        {
            // Lo �nico que hace pursuit es estimar la posici�n futura del target, as� que hecho esto funciona
            // como el steering de Arrive (o podr�a usar tambien el Seek).
            this._arrive = new Arrive(deceleration, decelerationBeginsAtDistance);

            this.Target = null;
        }
    }
}