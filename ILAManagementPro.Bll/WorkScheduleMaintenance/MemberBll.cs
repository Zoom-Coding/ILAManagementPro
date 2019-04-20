using ILAManagementPro.Data.Repositories;
using ILAManagementPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILAManagementPro.Bll.WorkScheduleMaintenance
{
    public class MemberBLL
    {
        public static HeaderEntity GetMember(string memberNumber)
        {
            HeaderEntity headerEntity1 = (HeaderEntity)null;
            string user = memberNumber;
            BadgeEntity badgeEntity = (BadgeEntity)null;
            int result;
            if (int.TryParse(memberNumber, out result))
                badgeEntity = new AbsBadgeRepository().GetByBadgeNumber(result);
            HeaderEntity headerEntity2;
            if (badgeEntity != null)
            {
                headerEntity2 = new HeaderRepository().Get(((Decimal)badgeEntity.CardNumber).ToString());
            }
            else
            {
                if (memberNumber.Length == 0)
                    return headerEntity1;
                if (memberNumber.Length == 4)
                    memberNumber = "14140" + memberNumber;
                else if (memberNumber.Length == 5)
                    memberNumber = "1414" + memberNumber;
                headerEntity2 = new HeaderRepository().Get(memberNumber);
            }
            if (headerEntity2 == null && SecurityBll.GetUserSecurity(user) != null)
            {
                headerEntity2 = new HeaderEntity();
                headerEntity2.Id = user;
                headerEntity2.DisplayName = user;
                headerEntity2.HeaderMember = false;
                headerEntity2.DailySuspension = false;
                headerEntity2.Active = false;
            }
            return headerEntity2;
        }

        public static void AddWorkScheduleMaintSecurity(
          HeaderEntity _memberUser,
          HeaderEntity _authorUser)
        {
            UserSecurityRepository securityRepository = new UserSecurityRepository();
            UserSecurityEntity userSecurity = SecurityBll.GetUserSecurity(_memberUser.Id);
            if (userSecurity == null)
            {
                UserSecurityEntity entity = new UserSecurityEntity();
                entity.LogIn = _memberUser.Id;
                HeaderEntity headerEntity = new HeaderRepository().Get(_memberUser.Id);
                if (headerEntity != null)
                    entity.UserName = headerEntity.FirstName.Trim() + " " + headerEntity.MiddleInitial.Trim() + " " + headerEntity.LastName.Trim();
                entity.WorkScheduleMaintenance = (bool?)new bool?(true);
                entity.User = _authorUser.Id.Trim();
                securityRepository.Add(entity);
            }
            else
            {
                userSecurity.WorkScheduleMaintenance = (bool?)new bool?(true);
                userSecurity.User = _authorUser.Id.Trim();
                securityRepository.Update(userSecurity);
            }
        }

        public static void AddMemberDailySuspension(NoteEntity note)
        {
            new MemberSuspendRepository().Add(note);
        }

        public static List<CallBackEntity> GetActiveCallBacksByDate(DateTime date)
        {
            return new AbsCallBackRepository().GetAllActiveByDate(date);
        }

        public static List<CallBackEntity> GetActiveCallBacks()
        {
            return new AbsCallBackRepository().GetAllActive().Where<CallBackEntity>((Func<CallBackEntity, bool>)(c => (DateTime)c.CallBackDateTime < DateTime.Now.Date)).ToList<CallBackEntity>();
        }

        public static void AddCallBack(CallBackEntity callback)
        {
            new AbsCallBackRepository().Add(callback);
        }

        public static void DeleteCallBack(CallBackEntity callback)
        {
            new AbsCallBackRepository().Delete(callback);
        }

        public static void UpdateCallBack(CallBackEntity callback)
        {
            new AbsCallBackRepository().Update(callback);
        }
    }
}